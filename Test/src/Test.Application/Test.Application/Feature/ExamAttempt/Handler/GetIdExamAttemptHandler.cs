using MediatR;
using Test.Application.Feature.ExamAttempt.Queries;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.ExamAttempt.Handler;

public class GetIdExamAttemptHandler : IRequestHandler<GetByIdExamAttemptQueries, ExamAttemptCreationModel>
{
    private readonly IExamAttemptRepository _examAttemptRepository;
    public GetIdExamAttemptHandler(IExamAttemptRepository examAttemptRepository)
    {
        _examAttemptRepository = examAttemptRepository;
    }

    public async Task<ExamAttemptCreationModel> Handle(GetByIdExamAttemptQueries request, CancellationToken cancellationToken)
    {
        var examatempt = await _examAttemptRepository.GetFirstAsync(u => u.StudentId == request.id);
        if (examatempt == null)
        {
            return null;

        }
      
        var result = new ExamAttemptCreationModel()
        {
            StudentId = request.id,
            Score = examatempt.Score,
            ExamId  = examatempt.ExamId,
            NumberOfAttempt = examatempt.NumberOfAttempt,
            
        };
        return result;
    }
}

