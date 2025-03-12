using MediatR;
using Test.DataAccess.DTOs.Creation;

namespace Test.Application.Feature.User.Command;

public record ForgotPassowrdCommand(ForgotPassowrdDTO ForgotPassowrdDTO) : IRequest<string>;

