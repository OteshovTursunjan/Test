using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.Get;

namespace Test.Application.Feature.Question.Queries;

public record GetQuestionByIdQueries(Guid id) : IRequest<GetQuestionModel>
{
}
