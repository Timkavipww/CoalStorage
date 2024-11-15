
namespace CoalStorage.Core.Common;

public class BaseAuditableEntity
{
    [JsonIgnore]
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow.DateTime;
    
    [JsonIgnore]
    public string CreatedBy { get; set; } = "Admin";
    
    [JsonIgnore]
    public DateTimeOffset LastModified { get; set; }

    [JsonIgnore]
    public string LastModifiedBy { get; set; }
}
