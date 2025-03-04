using MediatR;
using Test.Application.Feature.ExamSession.Command;
using Test.DataAccess;
using Test.DataAccess.DTOs.TestModel;

namespace Test.Application.Feature.ExamSession.Handler;

public class SubmitExamHandler : IRequestHandler<SubmitExamCommand, ExamResultModel>
{
    public readonly DatabaseContext _context;
    public SubmitExamHandler(DatabaseContext context)
    {
        _context = context;
    }
    public Task<ExamResultModel> Handle(SubmitExamCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
