using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Question.Queries;
using Test.DataAccess.DTOs.Get;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Question.Handler;

public class GetQuestionHandler : IRequestHandler<GetQuestionByIdQueries, GetQuestionModel>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionHandler(IAnswerRepository answerRepository, IQuestionRepository questionRepository)
    {
        _answerRepository = answerRepository;
        _questionRepository = questionRepository;
    }

    public async Task<GetQuestionModel> Handle(GetQuestionByIdQueries request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetFirstAsync(u => u.id == request.id);
        var answer = await _answerRepository.GetFirstAsync(u => u.QuestionID == request.id);
        if(question == null || answer == null)
        {
            return null;
        }
        var questionModel = new GetQuestionModel()
        {
            ExamId = question.ExamId,
            Text = question.Text,
            A = answer.A,
            B = answer.B,
            C = answer.C,
            D = answer.D,
            RightAnswer = answer.RightAnswer,
        };
        return questionModel;
    }
}
