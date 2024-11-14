
namespace CoalStorage.Core.Common;

public class BaseAuditableEntity
{
#nullable enable

    [JsonIgnore]
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow.DateTime;

    public string? CreatedBy { get; set; }
    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
