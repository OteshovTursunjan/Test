using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.DTOs.Get;

namespace Test.DataAccess.DTOs.TestModel;

public class ExamSessionModel
{
    public Guid SessionId { get; set; }
    public Guid ExamId { get; set; }
    public string SubjectName { get; set; }
    public int TotalQuestions { get; set; }
    public List<AnswerGetModel> Questions { get; set; }
}
