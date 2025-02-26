using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Coomon;

namespace Tests.Core.Enteties
{
    public class StudentResult : BaseEntity, IAuditedEntity
    {
        public ApplicationUser User { get; set; }
        public Guid StudentID { get; set; }
        public Exam Exam { get; set; }
        public Guid ExamId { get; set; }
        public int Score { get; set; }
        public double Percentage {  get; set; }

        public string? CreatBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdateBY { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
