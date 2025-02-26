using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.Creation;
using Test.DataAccess.DTOs.Update;

namespace Test.Application.Feature.ExamAttempt.Command;

public record UpdateExamAttemptCommand(UpdateExamAttempt model): IRequest<bool>;

