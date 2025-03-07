using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.TestSession;

namespace Test.Application.Feature.TestSesion.Command;

public  record SubmitExamCommand(ExamSubmissionModel ExamSubmissionModel): IRequest<ExamResultModel>;

