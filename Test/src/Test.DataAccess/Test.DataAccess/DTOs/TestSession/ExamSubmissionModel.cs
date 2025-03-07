using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.TestSession;

public  class ExamSubmissionModel
{
    public Guid SessionId { get; set; }
    public required List<StudentAnswerSubmissionModel> Answers { get; set; }
}
