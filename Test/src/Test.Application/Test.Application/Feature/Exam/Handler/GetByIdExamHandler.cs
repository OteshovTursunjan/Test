using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Exam.Queries;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Exam.Handler;

public class GetByIdExamHandler : IRequestHandler<GetByIdExamQueries, ExamCreationModel>
{
    private readonly IExamRepository _examRepository;
    public GetByIdExamHandler(IExamRepository examRepository)
    {
        _examRepository = examRepository;
    }

    public async Task<ExamCreationModel> Handle(GetByIdExamQueries request, CancellationToken cancellationToken)
    {
       var exam = await _examRepository.GetFirstAsync(u => u.id == request.id);
        if (exam == null) 
        {
            return null;
        }
        var res = new ExamCreationModel()
        {
            QuestionCount = exam.QuestionCount,
           SubjectId = exam.SubjectId,
        };
        return res;
    }
}
