using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Feature.ExamAttempt.Command;
using Test.Application.Feature.ExamAttempt.Queries;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.DTOs.Update;

namespace Test.Controllers;

public class ExamAttempt : Controller
{
    private readonly IMediator mediator;
    public ExamAttempt(IMediator mediator)
    {
       this.mediator    = mediator;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("CreateExamAttempt")]
    public async Task<IActionResult> CreateAsync(ExamAttemptCreationModel examAttemptCreationModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await mediator.Send(new CreateExamAttemptCommand(examAttemptCreationModel));
        return Ok(result);
    }
    [HttpGet("GetExamAttempt")]
    public async Task<IActionResult> GetExamAttempt(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await mediator.Send(new GetByIdExamAttemptQueries(id));
        return Ok(result);

    }
    [HttpPut("UpdateExamAttempt")]
    public async Task<IActionResult> UpdateExamAttempt(UpdateExamAttempt updateExamAttempt)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await mediator.Send(new UpdateExamAttemptCommand(updateExamAttempt));
        return Ok(result);
    }
    [HttpDelete("DeleteExamAttempt")]
    public async Task<IActionResult> DeleteExamAttempt(Guid id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await mediator.Send(new DeleteExamAttemptCommand(id));
        return Ok(result);
    }

}
