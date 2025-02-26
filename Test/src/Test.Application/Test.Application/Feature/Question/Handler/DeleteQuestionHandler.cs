using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Question.Command;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Question.Handler
{
    public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionCommand, bool>
    {
        private readonly IQuestionRepository _questionRepository;
        public readonly  IAnswerRepository _answerRepository;
        public DeleteQuestionHandler(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.GetFirstAsync(u => u.id == request.id);
            var answer = await _answerRepository.GetFirstAsync(u => u.id == question.Answer.id);

            if(question == null || answer == null )
            {
                return false;
            }
            await _questionRepository.DeleteAsync(question);
            await _answerRepository.DeleteAsync(answer);
            return true;
        }
    }
}
