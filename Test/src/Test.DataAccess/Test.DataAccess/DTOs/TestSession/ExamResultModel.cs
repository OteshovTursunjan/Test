using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.TestSession;

public  class ExamResultModel
{
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
    public double Percentage { get; set; }
    public bool IsFail { get; set; }
}
