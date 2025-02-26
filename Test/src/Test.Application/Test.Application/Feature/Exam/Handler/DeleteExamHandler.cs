using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Exam.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Exam.Handler;

public class DeleteExamHandler : IRequestHandler<DeleteExamCommand, bool>
{
    public readonly IExamRepository _examRepository;
    public DeleteExamHandler(IExamRepository examRepository)
    {
        _examRepository = examRepository;
    }

    public async Task<bool> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
    {
        var exam = await _examRepository.GetFirstAsync(u => u.id == request.id);
        if (exam == null)
        {
            return false;
        }
        await _examRepository.DeleteAsync(exam);
        return true;
    }
}
