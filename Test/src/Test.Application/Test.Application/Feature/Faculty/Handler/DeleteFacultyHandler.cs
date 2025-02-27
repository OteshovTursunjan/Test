using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Faculty.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Faculty.Handler;

public  class DeleteFacultyHandler : IRequestHandler<DeleteFacultyCommand, bool>
{
    private readonly IFacultyRepository _facultyRepository;
    public DeleteFacultyHandler(IFacultyRepository facultyRepository)
    {
        _facultyRepository = facultyRepository;
    }

    public async Task<bool> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
    {
        var faculty = await _facultyRepository.GetFirstAsync(u => u.id == request.id);
        if (faculty == null)
        {
            return false;
        }
        await _facultyRepository.DeleteAsync(faculty);
        return true;
    }
}
