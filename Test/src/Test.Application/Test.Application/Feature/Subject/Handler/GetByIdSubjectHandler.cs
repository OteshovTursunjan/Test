using MediatR;
using Test.Application.Feature.Subject.Queries;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Subject.Handler;

public class GetByIdSubjectHandler : IRequestHandler<GetByIdSubjectQueries, SubjectCreationModel>
{
    private readonly ISubjectRepository subjectRepository;
    public GetByIdSubjectHandler(ISubjectRepository subjectRepository)
    {
        this.subjectRepository = subjectRepository;
    }

    public async Task<SubjectCreationModel> Handle(GetByIdSubjectQueries request, CancellationToken cancellationToken)
    {
        var subject = await subjectRepository.GetFirstAsync(u => u.id == request.id);
        if (subject == null)
        {
            return null;

        }
        var result = new SubjectCreationModel()
        {
            Name = subject.Name,
            FacultyID = subject.FacultyID,
        };
        return result;
    }
}
