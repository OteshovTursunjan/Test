using MediatR;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.Update;

namespace Test.Application.Feature.Subject.Command;

public record UpdateSubjectCommand(SubjectUpdateModel SubjectUpdateModel): IRequest<bool>; 

