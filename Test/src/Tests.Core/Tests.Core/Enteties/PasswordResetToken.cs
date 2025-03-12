

using Tests.Core.Coomon;

namespace Tests.Core.Enteties;

public  class PasswordResetToken : BaseEntity, IAuditedEntity
{
    public string UserId { get; set; }
    public string Code { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string? CreatBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdateBY { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
