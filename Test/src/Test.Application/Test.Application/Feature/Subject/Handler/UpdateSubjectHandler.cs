using MediatR;using Test.Application.Feature.Subject.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Subject.Handler;

public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectCommand, bool>
{
    private readonly ISubjectRepository subjectRepository;
    public UpdateSubjectHandler(ISubjectRepository subjectRepository)
    {
        this.subjectRepository = subjectRepository;
    }

    public async Task<bool> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = await subjectRepository.GetFirstAsync(u => u.id == request.SubjectUpdateModel.id);
        if (subject == null)
        {
            return false;
        }
        subject.Name = request.SubjectUpdateModel.Name;
        subject.FacultyID = request.SubjectUpdateModel.FacultyID;

        await subjectRepository.UpdateAsync(subject);
        return true;
    }
}
