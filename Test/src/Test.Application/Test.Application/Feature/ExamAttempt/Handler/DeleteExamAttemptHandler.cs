using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.ExamAttempt.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.ExamAttempt.Handler;

public class DeleteExamAttemptHandler : IRequestHandler<DeleteExamAttemptCommand, bool>
{
    private readonly IExamAttemptRepository _examAttemptRepository;
    public DeleteExamAttemptHandler(IExamAttemptRepository examAttemptRepository)
    {
        _examAttemptRepository = examAttemptRepository;
    }

    public async Task<bool> Handle(DeleteExamAttemptCommand request, CancellationToken cancellationToken)
    {
        var examatempt = await _examAttemptRepository.GetFirstAsync(u => u.id == request.id);
        if (examatempt == null)
        {
            return false;
        }
        await _examAttemptRepository.DeleteAsync(examatempt);
        return true;
    }
}
