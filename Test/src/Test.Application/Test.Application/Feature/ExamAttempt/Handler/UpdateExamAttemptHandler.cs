using MediatR;
using Test.Application.Feature.ExamAttempt.Command;

using Test.DataAccess.Repository;

namespace Test.Application.Feature.ExamAttempt.Handler;

public  class UpdateExamAttemptHandler : IRequestHandler<UpdateExamAttemptCommand, bool>
{
    private readonly IExamAttemptRepository _examAttemptRepository;
    public UpdateExamAttemptHandler(IExamAttemptRepository examAttemptRepository)
    {
        _examAttemptRepository = examAttemptRepository;
    }

    public async Task<bool> Handle(UpdateExamAttemptCommand request, CancellationToken cancellationToken)
    {
       var exam = await _examAttemptRepository.GetFirstAsync(u => u.StudentId == request.model.StudentId);
        if (exam == null)
        {
            return false;
        }
        exam.StudentId = request.model.StudentId;
        exam.NumberOfAttempt = request.model.NumberOfAttempt;
        await _examAttemptRepository.UpdateAsync(exam);
        return true;

    }
}
