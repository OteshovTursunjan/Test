using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Coomon;

namespace Tests.Core.Enteties;

public class StudentAnswer : BaseEntity, IAuditedEntity
{
    public ExamSession Session { get; set; }
    public Guid ExamSessionID { get; set; }
    public Question Question { get; set; }
    public Guid QuestionID { get; set; }
    public  string SelectAnswer { get; set; }
    public string? CreatBy { get; set; }
    public DateTime? CreatedOn { get; set; }

    public string? UpdateBY { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
