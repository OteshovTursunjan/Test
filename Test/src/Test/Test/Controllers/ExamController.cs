using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Feature.Exam.Command;
using Test.Application.Feature.Exam.Queries;
using Test.DataAccess.DTOs.Creation;

namespace Test.Controllers
{
    public class ExamController : Controller
    {
        private readonly IMediator mediator;
        public ExamController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateExam")]
         public async Task<IActionResult> CreateExam(ExamCreationModel examCreationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send( new CreateExamCommand(examCreationModel));    
            return Ok(res);
        }
        [HttpGet("GetExam")]
        public async Task<IActionResult> GetExam(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new GetByIdExamQueries(id));
            return Ok(res);
        }
        [HttpPut("UpdateExam")]
        public async Task<IActionResult> UpdateExam([FromQuery] Guid id, ExamCreationModel examCreationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new UpdateExamCommand(id,examCreationModel));
            return Ok(res);
        }

        [HttpDelete("DeleteExam")]
        public async Task<IActionResult> DeleteExam(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new DeleteExamCommand(id));
            return Ok(res);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
