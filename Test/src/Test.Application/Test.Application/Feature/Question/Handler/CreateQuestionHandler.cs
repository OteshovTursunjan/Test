using MediatR;
using Test.Application.Feature.Question.Command;
using Test.DataAccess.Repository;
using Tests.Core.Enteties;

namespace Test.Application.Feature.Question.Handler;

public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, bool>
{
    public readonly IQuestionRepository questionRepository;
    public readonly IAnswerRepository answerRepository;
    public CreateQuestionHandler(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
    {
        this.questionRepository = questionRepository;
        this.answerRepository = answerRepository;
    }

    public async Task<bool> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = new Tests.Core.Enteties.Question()
        {
            Text = request.questionCreationModel.Text,
            ExamId = request.questionCreationModel.ExamId,
        };
        var s1 =  await questionRepository.AddAsync(question);
        var answer = new Tests.Core.Enteties.Answer()
        {
            QuestionID = question.id,
            A = request.questionCreationModel.A,
            B = request.questionCreationModel.B,
            C = request.questionCreationModel.C,
            D = request.questionCreationModel.D,
            RightAnswer = request.questionCreationModel.RightAnswer,
        };
        var s2 = await answerRepository.AddAsync(answer);
        if(s1 != null &&  s2 != null)
        {
            return true;
        }
        return false;

    }
}
