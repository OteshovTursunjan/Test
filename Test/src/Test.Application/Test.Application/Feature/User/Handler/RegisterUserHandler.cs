using MediatR;
using Microsoft.AspNetCore.Identity;
using Test.Application.Feature.User.Command;
using Tests.Core.Enteties;

namespace Test.Application.Feature.User.Handler;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand , bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public RegisterUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.RegisterUser.Email);
        if (user != null)
        {
            return false;
        }
        var newuser = new ApplicationUser()
        {
            
            UserName = request.RegisterUser.Email,
            Email = request.RegisterUser.Email,
            FirstName = request.RegisterUser.FirstName,
            LastName = request.RegisterUser.LastName
        };
        var result = await _userManager.CreateAsync(newuser);
        if (!result.Succeeded)
        {
            return false;
        }
        return true;
    }
}
