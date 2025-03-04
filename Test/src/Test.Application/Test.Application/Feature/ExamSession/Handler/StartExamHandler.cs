using MediatR;
using Test.Application.Feature.ExamSession.Command;
using Test.DataAccess;
using Test.DataAccess.DTOs.TestModel;

namespace Test.Application.Feature.ExamSession.Handler;
public class StartExamHandler : IRequestHandler<StartExamCommand, ExamSessionModel>
{
    public readonly DatabaseContext context;
    public StartExamHandler(DatabaseContext context)
    {
        this.context = context;
    }
    public  Task<ExamSessionModel> Handle(StartExamCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
