using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.Get;

public class GetExamAttemptModel
{
    public int NumberOfAttempt { get; set; }

    public Guid StudentId { get; set; }

    public Guid ExamId { get; set; }

    public int Score { get; set; }  
}
