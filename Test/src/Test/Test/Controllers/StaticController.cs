using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Feature.Statics.Queries;

namespace Test.Controllers;

public class StaticController : Controller
{
    private readonly IMediator _mediator;
    public StaticController(IMediator mediator)
    {
            _mediator = mediator;   
    }
    [HttpGet("GetStatics")]
    public async Task<IActionResult> GetStatic(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await _mediator.Send(new GetStaticQueries(id));
        return Ok(res);
    }
    public IActionResult Index()
    {
        return View();
    }
}
