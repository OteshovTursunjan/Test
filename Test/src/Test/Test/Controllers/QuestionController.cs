using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Feature.Question.Command;
using Test.DataAccess.DTOs.Creation;

namespace Test.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IMediator mediator;
        public QuestionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Create_Question")]
        public async Task<IActionResult> CreateQuestion(QuestionCreationModel questionCreationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new CreateQuestionCommand(questionCreationModel));
            return res == null ? NotFound():Ok(res);
        }
    }
}
