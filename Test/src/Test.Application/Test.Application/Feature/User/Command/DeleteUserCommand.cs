using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.Register;

namespace Test.Application.Feature.User.Command;

public record DeleteUserCommand(LoginUser LoginUser ): IRequest<bool>
{
}
