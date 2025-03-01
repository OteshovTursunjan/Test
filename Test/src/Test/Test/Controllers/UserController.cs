using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Feature.User.Command;
using Test.DataAccess.DTOs.Register;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new RegisterUserCommand(registerUser));
            return res == null ? NotFound() : Ok(res);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginUser loginUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await mediator.Send(new LoginUserCommand(loginUser));
            return res == null ? NotFound() : Ok(res);
        }

    }
}
