using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Coomon;

namespace Tests.Core.Enteties
{
    public class ExamSession : BaseEntity, IAuditedEntity
    {
        
        public Exam Exam { get; set; }
        public Guid ExamID { get; set; }
        public Guid StudentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ExamSessionStatus Status { get; set; }
        public string? CreatBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdateBY { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public enum ExamSessionStatus
    {
        NotStarted,
        InProgress,
        Completed
    }
}
