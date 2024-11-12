namespace CoalStorage.Core.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
#nullable enable
    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
