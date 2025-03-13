using Tests.Core.Coomon;

namespace Tests.Core.Enteties;

public class Statictis: BaseEntity, IAuditedEntity
{
    public Guid SubjectId { get; set; }
    public double AmountPercentage { get; set; }
    public int NumberOfStudent {  get; set; }
    public string? CreatBy { get; set; }
    public DateTime? CreatedOn { get; set; }

    public string? UpdateBY { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
