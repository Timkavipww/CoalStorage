
namespace CoalStorage.Core.Common;

public class BaseAuditableEntity
{
    [JsonIgnore]
    public DateTime Created { get; set; } = DateTime.Now;
    
    [JsonIgnore]
    public string CreatedBy { get; set; } = "Admin";
    
    [JsonIgnore]
    public DateTime LastModified { get; set; }

    [JsonIgnore]
    public string LastModifiedBy { get; set; }
}
