namespace CoalStorage.Core.Entities;

public class MainStorageCargo : BaseAuditableEntity
{
    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; } 

    public long AreaId { get; set; } 
    public Area Area { get; set; }

    public long PicketId { get; set; }
    public Picket Picket { get; set; }

    public double Weight { get; set; }
}