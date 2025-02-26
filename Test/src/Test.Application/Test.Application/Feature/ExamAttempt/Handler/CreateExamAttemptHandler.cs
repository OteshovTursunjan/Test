using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.ExamAttempt.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.ExamAttempt.Handler;

public class CreateExamAttemptHandler : IRequestHandler<CreateExamAttemptCommand, bool>
{
    private readonly IExamAttemptRepository examAttemptRepository;
    public CreateExamAttemptHandler(IExamAttemptRepository examAttemptRepository)
    {
        this.examAttemptRepository = examAttemptRepository;
    }

    public async Task<bool> Handle(CreateExamAttemptCommand request, CancellationToken cancellationToken)
    {
        var examattempt = new Tests.Core.Enteties.ExamAttempt()
        {
            StudentId = request.ExamAttemptCreationModel.StudentId,
            NumberOfAttempt = request.ExamAttemptCreationModel.NumberOfAttempt,
            Score  = request.ExamAttemptCreationModel.Score,
            ExamId = request.ExamAttemptCreationModel.ExamId
        };

        await examAttemptRepository.AddAsync(examattempt);
        return true;
    }
}

