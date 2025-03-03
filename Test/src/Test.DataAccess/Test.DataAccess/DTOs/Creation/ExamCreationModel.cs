using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess.DTOs.Creation;

public  class ExamCreationModel
{
   // public Subject Subject { get; set; }
    public Guid SubjectId { get; set; }
    public int QuestionCount { get; set; }
}
