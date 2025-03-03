using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Feature.Subject.Command;
using Test.Application.Feature.Subject.Queries;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.DTOs.Update;

namespace Test.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IMediator mediator;
        public SubjectController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateSubject")]
        public async Task<IActionResult> CreateSubject(SubjectCreationModel subjectCreationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new CreateSubjectCommand(subjectCreationModel));
            return Ok(res);
        }
        [HttpGet("GetSubject")]
        public async Task<IActionResult> GetSubject(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new GetByIdSubjectQueries(id));
            return Ok(res);
        }
        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(SubjectUpdateModel subjectUpdateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new UpdateSubjectCommand(subjectUpdateModel));
            return Ok(res);
        }
        [HttpDelete("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new  DeleteSubjectCommand(id));
            return Ok(res);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
