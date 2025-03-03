using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Feature.Faculty.Command;
using Test.Application.Feature.Faculty.Queries;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.DTOs.Update;

namespace Test.Controllers;
public class FacultyController : Controller
{
    private readonly IMediator mediator;
    public FacultyController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("CreateFaculty")]
    public async Task<IActionResult> CreateFaculty(FacultyCreationModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await mediator.Send(new CreateFacultyCommand(model));
        return Ok(res);
    }
    [HttpGet("GetFaculty{id}")]
    public async Task<IActionResult> GetFacultyId(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await mediator.Send(new GetFacultyByIdQueres(id));
        return Ok(res);
    }
    [HttpPut("UpdateFaculty")]
    public async Task<IActionResult> UpdateFaculty(FacultyUpdateModel facultyUpdateModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await mediator.Send(new UpdateFacultyCommand(facultyUpdateModel));
        return Ok(res);
    }
    [HttpDelete("DeleteFaculty")]
    public async Task<IActionResult> DeleteFaculty(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await mediator.Send(new DeleteFacultyCommand(id));
        return Ok(res);
    }
}
