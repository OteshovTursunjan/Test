using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Exam.Command;
using Test.DataAccess.Repository;
using Tests.Core.Enteties;

namespace Test.Application.Feature.Exam.Handler;
public class CreateExamHandler : IRequestHandler<CreateExamCommand, bool>
{
    public readonly IExamRepository _examRepository;
    public CreateExamHandler(IExamRepository examRepository)
    {
        _examRepository = examRepository;
    }

    public async Task<bool> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        var exam = new Tests.Core.Enteties.Exam()
        {
            SubjectId = request.examCreationModel.SubjectId,
            QuestionCount = request.examCreationModel.QuestionCount,
        };
        
        var res = await _examRepository.AddAsync(exam);
        if(res == null)
        {
            return false;
        }
        return true;
    }
}
