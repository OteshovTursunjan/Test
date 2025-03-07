using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Application.Feature.TestSesion.Command;
using Test.DataAccess;
using Test.DataAccess.DTOs.TestSession;
using Test.Shared;
using Tests.Core.Enteties;

namespace Test.Application.Feature.TestSesion.Handler;

public class StartExamHandler : IRequestHandler<StartExamCommand, ExamSessionModel>
{
    private readonly IClaimService _claimService;
    private readonly DatabaseContext context;
    public StartExamHandler(DatabaseContext context, IClaimService claimService)
    {
        this.context = context;
        _claimService = claimService;
    }
    public async Task<ExamSessionModel> Handle(StartExamCommand request, CancellationToken cancellationToken)
    {
        var exam = await context.exams
           .Include(e => e.Subject)
           .FirstOrDefaultAsync(e => e.id == request.StartExamSessionModel.ExamId);

        if (exam == null)
        {
            return null;
        }
        var questions = await context.questions
            .Where(q => q.ExamId == exam.id)
            .Include(q => q.Answer)
            .Select(q => new ExamQuestionDTO
            {
                Id = q.id,
                Text = q.Text,
                Answers = new AnswerOptionDTO
                {
                    A = q.Answer.A,
                    B = q.Answer.B,
                    C = q.Answer.C,
                    D = q.Answer.D
                }
            }).ToListAsync();
        if (questions == null)
        {
            return null;
        }
        string userid = _claimService.GetUserId();
        var examSession = new Tests.Core.Enteties.ExamSession
        {
            ExamID = exam.id,
            StudentId = request.StartExamSessionModel.StudentId,
            StartTime = DateTime.UtcNow,
            Status = ExamSessionStatus.InProgress
        };

        await context.AddAsync(examSession);
        await context.SaveChangesAsync();

        return (new ExamSessionModel
        {
            SessionId = examSession.id,
            ExamId = exam.id,
            SubjectName = exam.Subject.Name,
            Questions = questions
        });
    }
}

