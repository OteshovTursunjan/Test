using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Question.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Question.Handler;

public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, bool>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IQuestionRepository _questionRepository;
    public UpdateQuestionHandler(IAnswerRepository answerRepository, IQuestionRepository questionRepository)
    {
        _answerRepository = answerRepository;
        _questionRepository = questionRepository;
    }

    public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = new Tests.Core.Enteties.Question()
        {
            Text = request.questionCreationModel.Text,
            ExamId = request.questionCreationModel.ExamId,
        }; 
        var answer = new Tests.Core.Enteties.Answer()
        {
            QuestionID = question.id,
            A = request.questionCreationModel.A,
            B = request.questionCreationModel.B,
            C = request.questionCreationModel.C,
            D = request.questionCreationModel.D,
            RightAnswer = request.questionCreationModel.RightAnswer,
        };
        var s1 =  await _answerRepository.UpdateAsync(answer);
        var s2 =  await _questionRepository.UpdateAsync(question);   
        if(s1 == null || s2 == null) { return false; }
        return true;
    }
}
