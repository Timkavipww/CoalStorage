namespace CoalStorage.Core.Entities;

public class MainStorage : BaseAuditableEntity
{
    public List<Picket> Pickets { get; private set; } = new List<Picket>();
    public List<Area> Areas { get; private set; } = new List<Area>();
    public ICollection<StoragePicket> StoragePickets { get; set; } = new List<StoragePicket>();

}
