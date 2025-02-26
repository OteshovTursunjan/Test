using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.Creation;

namespace Test.Application.Feature.Exam.Command;

public record UpdateExamCommand( Guid id , ExamCreationModel ExamCreationModel): IRequest<bool>;

