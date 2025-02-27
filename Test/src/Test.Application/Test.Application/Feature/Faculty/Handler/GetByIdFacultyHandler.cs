using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Faculty.Queries;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Faculty.Handler;

public  class GetByIdFacultyHandler : IRequestHandler<GetFacultyByIdQueres, FacultyCreationModel>
{
    private readonly IFacultyRepository facultyRepository;  
    public GetByIdFacultyHandler(IFacultyRepository facultyRepository)
    {
        this.facultyRepository = facultyRepository;
    }

    public async Task<FacultyCreationModel> Handle(GetFacultyByIdQueres request, CancellationToken cancellationToken)
    {
        var faculty = await facultyRepository.GetFirstAsync(u => u.id == request.id);
        if (faculty == null)
        {
            return null;

        }
        var res = new FacultyCreationModel
        {
            Name = faculty.Name,
        };
        return res;
    }
}
