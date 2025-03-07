using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.DTOs.TestSession;

public class StudentAnswerSubmissionModel
{
    public Guid QuestionId { get; set; }
    public string? SelectedAnswer { get; set; }
}
