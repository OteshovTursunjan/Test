using MediatR;
using Test.DataAccess.DTOs.Creation;

namespace Test.Application.Feature.Question.Command;
public record CreateQuestionCommand(QuestionCreationModel questionCreationModel):IRequest<bool>;

