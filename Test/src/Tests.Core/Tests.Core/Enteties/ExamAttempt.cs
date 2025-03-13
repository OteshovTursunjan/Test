using Tests.Core.Coomon;

namespace Tests.Core.Enteties
{
    public  class ExamAttempt : BaseEntity, IAuditedEntity
    {
        public int NumberOfAttempt {  get; set; }
        public Guid StudentId { get; set; }
        public string? CreatBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public string? UpdateBY { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
