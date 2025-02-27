using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Subject.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Subject.Handler;

public class CreateSubjectHandler : IRequestHandler<CreateSubjectCommand, bool>
{
    private readonly ISubjectRepository subjectRepository;
    public CreateSubjectHandler(ISubjectRepository subjectRepository)
    {
        this.subjectRepository = subjectRepository;
    }

    public async Task<bool> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = await subjectRepository.GetFirstAsync(u => u.Name == request.SubjectCreationModel.Name);
        if (subject != null)
        {
            return false;
        }
        var res = new Tests.Core.Enteties.Subject()
        {
            Name = request.SubjectCreationModel.Name,
            FacultyID = request.SubjectCreationModel.FacultyID,
        };
        await subjectRepository.AddAsync(res);
        return true;
    }
}
