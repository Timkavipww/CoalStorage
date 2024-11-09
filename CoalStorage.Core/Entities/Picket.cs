namespace CoalStorage.Core.Entities;

public class Picket : BaseEntity
{
    public int Area { get; set; }
    public ICollection<StoragePicket> StoragePickets { get; set; } = new List<StoragePicket>();
    public ICollection<PicketArea> PicketAreas { get; set; } = new List<PicketArea>();

}
