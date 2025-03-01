using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.User.Queries;
using Test.DataAccess.DTOs.Register;
using Tests.Core.Enteties;

namespace Test.Application.Feature.User.Handler;

public  class GetUserByIdHandler : IRequestHandler<GetByIdUserQueries, ApplicationUser>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public GetUserByIdHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> Handle(GetByIdUserQueries request, CancellationToken cancellationToken)
    {
        ApplicationUser user = await _userManager.FindByEmailAsync(request.LoginUser.Email);
        if (user == null)
        {
            return null;
        }
      
        return user;
    }
}
