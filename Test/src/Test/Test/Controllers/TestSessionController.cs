using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Feature.TestSesion.Command;
using Test.DataAccess.DTOs.TestSession;

namespace Test.Controllers
{
    public class TestSessionController : Controller
    {
        private readonly IMediator mediator;
        public TestSessionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("StartExam")]
        public async Task<IActionResult> StartExam(StartExamSessionModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await mediator.Send(new StartExamCommand(model));
            return Ok(result);
        }
        [HttpPut("SubmitExam")]
        public async Task<IActionResult> SubmitExam([FromBody] ExamSubmissionModel examSubmissionModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await mediator.Send(new SubmitExamCommand(examSubmissionModel));
            return Ok(result);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
