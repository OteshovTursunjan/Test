using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Faculty.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Faculty.Handler;

public class UpdateFacultyHandler : IRequestHandler<UpdateFacultyCommand, bool>
{
    public readonly IFacultyRepository facultyRepository;
    public UpdateFacultyHandler(IFacultyRepository facultyRepository)
    {
        this.facultyRepository = facultyRepository;
    }

    public async Task<bool> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
    {
        var faculty = await facultyRepository.GetFirstAsync(u => u.id == request.FacultyUpdateModel.id);    
        if (faculty == null)
        {
            return false;

        }
        faculty.Name = request.FacultyUpdateModel.name;
        await facultyRepository.UpdateAsync(faculty);
        return true;
    }
}
