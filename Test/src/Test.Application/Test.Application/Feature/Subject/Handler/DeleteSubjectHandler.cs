using MediatR;
using Test.Application.Feature.Subject.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Subject.Handler;
public  class DeleteSubjectHandler : IRequestHandler<DeleteSubjectCommand, bool>
{

    private readonly ISubjectRepository subjectRepository;
    public DeleteSubjectHandler(ISubjectRepository subjectRepository)
    {
        this.subjectRepository = subjectRepository;
    }

    public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = await subjectRepository.GetFirstAsync(u=> u.id == request.id);
        if (subject == null)
        {
            return false;
        }
        await subjectRepository.DeleteAsync(subject);
        return true;
    }
}
