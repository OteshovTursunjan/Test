using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Coomon;

namespace Tests.Core.Enteties
{
    public class Question : BaseEntity, IAuditedEntity
    {
        public Guid ExamId { get; set; }
        public Exam Exams { get; set; }

        public string Text { get; set; }

        public Answer Answer { get; set; }  // Навигационное свойство (без FK!)

        public string? CreatBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdateBY { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
