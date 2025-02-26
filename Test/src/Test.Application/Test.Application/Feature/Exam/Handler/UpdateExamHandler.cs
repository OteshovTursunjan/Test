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

public class UpdateExamHandler : IRequestHandler<UpdateExamCommand, bool>
{
    public readonly IExamRepository _examRepository;
    public UpdateExamHandler(IExamRepository examRepository)
    {
        _examRepository = examRepository;
    }

    public async Task<bool> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
    {
        var exam = await _examRepository.GetFirstAsync(u=> u.id == request.id);
        if (exam == null)
        {
            return false;
        }
        var updatexam = new Tests.Core.Enteties.Exam()
        {
            SubjectId = request.ExamCreationModel.SubjectId,
            QuestionCount = request.ExamCreationModel.QuestionCount,
        };

        await _examRepository.UpdateAsync(updatexam);
        return true;
    }
}
