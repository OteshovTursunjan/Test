using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.Get;

namespace Test.Application.Feature.Statics.Queries;

public record GetStaticQueries(Guid id) : IRequest<StaticGetModel>;

