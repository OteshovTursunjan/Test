using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Application.Feature.TestSesion.Command;
using Test.DataAccess;
using Test.DataAccess.DTOs.TestSession;
using Test.DataAccess.Repository;
using Test.Shared;


namespace Test.Application.Feature.TestSesion.Handler;

public class SubmitExamHandler : IRequestHandler<SubmitExamCommand, ExamResultModel>
{
    private readonly IClaimService _claimService;
    private readonly DatabaseContext context;
    private readonly IStudentResultRepository _studentResultRepository;
   
    private readonly IExamRepository _examRepository;
    public SubmitExamHandler(DatabaseContext context, IStudentResultRepository studentResultRepository,
       IExamRepository examRepository,
       IClaimService claimService)
    {
        this.context = context;
        _claimService = claimService;
        _studentResultRepository = studentResultRepository;
      
        _examRepository = examRepository;
    }

    public async Task<ExamResultModel> Handle(SubmitExamCommand request, CancellationToken cancellationToken)
    {
        var examsession = await context.Sessions
            .FirstOrDefaultAsync(es => es.id == request.ExamSubmissionModel.SessionId, cancellationToken);

        if (examsession == null)
        {
            return null;
        }

        foreach (var answer in request.ExamSubmissionModel.Answers)
        {
            var studentAnswer = new Tests.Core.Enteties.StudentAnswer
            {
                QuestionID = answer.QuestionId,
                SelectAnswer = answer.SelectedAnswer,
                ExamSessionID = request.ExamSubmissionModel.SessionId,
            
            };
           await context.studentAnswers.AddAsync(studentAnswer);
        }

        var saveResult = await context.SaveChangesAsync(cancellationToken);

        int correctAnswer = await CalculateResult(request.ExamSubmissionModel.SessionId);

        var exam = await _examRepository.GetFirstAsync(u => u.id == examsession.ExamID);
        

        var answerpercangate = await CalculatePercantage(exam.id,correctAnswer);
        bool IsFail;
        if(answerpercangate >= 60)
        {
            IsFail = false;
        }
        else
        {
            IsFail = true;
        }

        var studentResult = new Tests.Core.Enteties.StudentResult()
        {
            StudentID = examsession.StudentId,
            ExamId = examsession.ExamID,
            Score = correctAnswer,
            Percentage = await CalculatePercantage(exam.id,correctAnswer),
        };
        await _studentResultRepository.AddAsync(studentResult);
        return new ExamResultModel
        {
            TotalQuestions = exam.QuestionCount,
            CorrectAnswers = correctAnswer,
            Percentage = await CalculatePercantage(exam.id, correctAnswer),
            IsFail = IsFail
        };
    }
    public async Task<double> CalculatePercantage(Guid id, int correct)
    {
        var exam = await _examRepository.GetFirstAsync(u => u.id == id);

        
        double correctAnswerPercentage = ((double)correct / exam.QuestionCount) * 100;

       
        return Math.Round(correctAnswerPercentage, 2);
    }
    public async Task<int> CalculateResult(Guid SessionId)
    {
        var studentAnswers = await context.Set<Tests.Core.Enteties.StudentAnswer>()
            .Where(sa => sa.ExamSessionID == SessionId)
            .ToListAsync();

        int correctCount = 0;

        foreach (var answer in studentAnswers)
        {
            var question = await context.Set<Tests.Core.Enteties.Question>()
                .Include(q => q.Answer)
                .FirstOrDefaultAsync(q => q.id == answer.QuestionID);

            if (question != null && question.Answer != null &&
                answer.SelectAnswer == question.Answer.RightAnswer)
            {
                correctCount++;
            }
        }

        return correctCount;
    }
}