using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.TestModel;

public  class StartExamSessionModel
{
    public Guid ExamId { get; set; }
    public Guid StudentId { get; set; }
}
