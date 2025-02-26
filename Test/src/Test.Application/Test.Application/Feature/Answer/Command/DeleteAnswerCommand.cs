using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Feature.Answer.Command;

public  class DeleteAnswerCommand(Guid id) : IRequest<bool>;