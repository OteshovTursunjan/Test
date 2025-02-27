using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Faculty.Command;
using Test.DataAccess.Repository;
using Tests.Core.Enteties;

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
        var faculty = await _facultyRepository.GetFirstAsync(u => u.Name == request.FacultyCreationModel.Name);
        if (faculty != null)
        {
            return false;
        }
        var newfaculty = new Tests.Core.Enteties.Faculty()
        {
            Name = request.FacultyCreationModel.Name,
        };
        await _facultyRepository.AddAsync(newfaculty);  
        return true;
    }
}
