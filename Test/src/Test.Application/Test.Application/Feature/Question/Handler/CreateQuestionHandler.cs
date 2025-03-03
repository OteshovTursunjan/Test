using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Application.Feature.Question.Command;
using Test.DataAccess;
using Test.DataAccess.Repository;
using Tests.Core.Enteties;
using static Dapper.SqlMapper;

namespace Test.Application.Feature.Question.Handler;

public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, bool>
{
    public readonly IQuestionRepository questionRepository;
    public readonly IAnswerRepository answerRepository;
    public readonly IExamRepository examRepository;
   
    public readonly DatabaseContext databaseContext;
    public CreateQuestionHandler(IQuestionRepository questionRepository,
        IAnswerRepository answerRepository, DatabaseContext databaseContext,
        IExamRepository examRepository)
    {
        this.questionRepository = questionRepository;
        this.answerRepository = answerRepository;
        this.examRepository = examRepository;
       this.databaseContext = databaseContext;
    }

    public async Task<bool> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var exam = await examRepository
            .GetFirstAsync(u => u.id == request.questionCreationModel.ExamId);
        var questioncount = await databaseContext.questions
            .Where(u => u.ExamId == request.questionCreationModel.ExamId)
            .ToListAsync();
        if(exam.QuestionCount <= questioncount.Count)
        {
            return false;
        }
        
        
        var  question = new Tests.Core.Enteties.Question()
        {
            Text = request.questionCreationModel.Text,
            ExamId = request.questionCreationModel.ExamId,
        };
        var s1 =  await questionRepository.AddAsync(question);
        var answer = new Tests.Core.Enteties.Answer()
        {
            QuestionID = question.id,
            A = request.questionCreationModel.A,
            B = request.questionCreationModel.B,
            C = request.questionCreationModel.C,
            D = request.questionCreationModel.D,
            RightAnswer = request.questionCreationModel.RightAnswer,
        };
        var s2 = await answerRepository.AddAsync(answer);
        if(s1 != null &&  s2 != null)
        {
            return true;
        }
        return false;

    }
}
