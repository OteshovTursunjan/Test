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
    private readonly IStaticRepository _staticRepository;
    public CreateSubjectHandler(ISubjectRepository subjectRepository, IStaticRepository staticRepository)
    {
        this.subjectRepository = subjectRepository;
        _staticRepository = staticRepository;
    }

    public async Task<bool> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var res = new Tests.Core.Enteties.Subject()
        {
            Name = request.SubjectCreationModel.Name,
            FacultyID = request.SubjectCreationModel.FacultyID,
        };
        
        await subjectRepository.AddAsync(res);
        var newSubject = await subjectRepository.GetFirstAsync(u => u.Name == res.Name);
        var Statics = new Tests.Core.Enteties.Statictis()
        {
            SubjectId = newSubject.id,
            NumberOfStudent = 0,
            AmountPercentage = 0
           
        };
        await _staticRepository.AddAsync(Statics);
        return true;
    }
}
