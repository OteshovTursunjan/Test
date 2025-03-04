using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.TestModel;

namespace Test.Application.Feature.ExamSession.Command;

public record StartExamCommand(StartExamSessionModel StartExamSessionModel) : IRequest<ExamSessionModel>;

