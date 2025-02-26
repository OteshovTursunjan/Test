using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Coomon;

namespace Tests.Core.Enteties
{
    public class Fail : BaseEntity, IAuditedEntity
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Guid StudentID { get; set; }
        public Subject Subject { get; set; }
        public Guid SubjectId { get; set; }
        public string? CreatBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public string? UpdateBY { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
