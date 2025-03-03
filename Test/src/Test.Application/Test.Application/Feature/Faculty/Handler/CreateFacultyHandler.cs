using MediatR;
using Test.Application.Feature.Faculty.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Faculty.Handler;

public class CreateFacultyHandler : IRequestHandler<CreateFacultyCommand, bool>
{
    private readonly IFacultyRepository _facultyRepository;
    public CreateFacultyHandler(IFacultyRepository facultyRepository)
    {
        _facultyRepository = facultyRepository;
    }
    public async Task<bool> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
    {
        var newfaculty = new Tests.Core.Enteties.Faculty()
        {
            Name = request.FacultyCreationModel.Name,
        };
        await _facultyRepository.AddAsync(newfaculty);  
        return true;
    }
}
