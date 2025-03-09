using MediatR;

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
        var question = await _questionRepository.GetFirstAsync(u => u.id == request.id);
        var answer = await _answerRepository.GetFirstAsync(u => u.QuestionID == request.id);
        question.Text = request.questionCreationModel.Text;
        question.ExamId = request.questionCreationModel.ExamId;
        var s2 =  await _questionRepository.UpdateAsync(question);
        answer.A = request.questionCreationModel.A;
        answer.B = request.questionCreationModel.B;
        answer.C = request.questionCreationModel.C;
        answer.D = request.questionCreationModel.D;
        answer.RightAnswer = request.questionCreationModel.RightAnswer;
        var s1 =  await _answerRepository.UpdateAsync(answer);
        if(s1 == null || s2 == null) { return false; }
        return true;
    }
}
