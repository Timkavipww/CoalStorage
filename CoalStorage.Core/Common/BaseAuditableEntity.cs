
namespace CoalStorage.Core.Common;

public class BaseAuditableEntity
{
    [JsonIgnore]
<<<<<<< HEAD
    public DateTime Created { get; set; } = DateTime.Now;
=======
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow.DateTime;
>>>>>>> 1b68ea92c4ce3538ac7461be9ea1fc9988f24133
    
    [JsonIgnore]
    public string CreatedBy { get; set; } = "Admin";
    
    [JsonIgnore]
<<<<<<< HEAD
    public DateTime LastModified { get; set; }
=======
    public DateTimeOffset LastModified { get; set; }
>>>>>>> 1b68ea92c4ce3538ac7461be9ea1fc9988f24133

    [JsonIgnore]
    public string LastModifiedBy { get; set; }
}
