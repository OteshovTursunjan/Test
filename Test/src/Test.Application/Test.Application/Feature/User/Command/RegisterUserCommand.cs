using MediatR;
using Test.DataAccess.DTOs.Register;

namespace Test.Application.Feature.User.Command;

public record RegisterUserCommand(RegisterUser RegisterUser) : IRequest<bool>;
