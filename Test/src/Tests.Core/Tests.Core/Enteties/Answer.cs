using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Coomon;

namespace Tests.Core.Enteties;

public class Answer : BaseEntity, IAuditedEntity
{
    public Guid QuestionID { get; set; }  // Внешний ключ
    public Question Question { get; set; } // Навигационное свойство

    public string A { get; set; }
    public string B { get; set; }
    public string C { get; set; }
    public string D { get; set; }
    public string RightAnswer { get; set; }

    public string? CreatBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdateBY { get; set; }
    public DateTime? UpdatedOn { get; set; }
}

