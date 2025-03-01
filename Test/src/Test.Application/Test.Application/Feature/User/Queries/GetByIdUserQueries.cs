using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.Register;
using Tests.Core.Enteties;

namespace Test.Application.Feature.User.Queries;

public record GetByIdUserQueries(LoginUser LoginUser): IRequest<ApplicationUser>;