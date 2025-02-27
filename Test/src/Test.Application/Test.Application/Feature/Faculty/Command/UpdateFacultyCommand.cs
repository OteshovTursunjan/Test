using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.Update;

namespace Test.Application.Feature.Faculty.Command;

public record UpdateFacultyCommand(FacultyUpdateModel FacultyUpdateModel): IRequest<bool>;

