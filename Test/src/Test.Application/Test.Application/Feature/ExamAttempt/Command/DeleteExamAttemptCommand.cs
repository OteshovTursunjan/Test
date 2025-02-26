using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Feature.ExamAttempt.Command;

public record DeleteExamAttemptCommand(Guid id) : IRequest<bool>;

