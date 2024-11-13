namespace CoalStorage.Core.Entities;

public class Area : BaseEntity
{
    public int MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; }
    public List<Picket> Pickets { get; set; } = new List<Picket>();
    public ICollection<PicketArea> PicketAreas { get; set; } = new List<PicketArea>();
    
}
