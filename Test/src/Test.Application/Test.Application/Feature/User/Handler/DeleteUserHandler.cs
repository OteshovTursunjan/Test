﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.User.Command;
using Tests.Core.Enteties;

namespace Test.Application.Feature.User.Handler;

public  class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public DeleteUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.email);
         if (user == null)
        {
            return false;
        }
         if(user.Id == "f29da660-2710-4c2c-a55a-05a1052c0cc0")
            return false;
         await _userManager.DeleteAsync(user);
        return true;
    }
}
