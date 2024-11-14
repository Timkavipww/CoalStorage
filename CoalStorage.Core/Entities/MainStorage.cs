namespace CoalStorage.Core.Entities;

public class MainStorage : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string StorageName { get; set; }
    public ICollection<Area> Areas { get; set; } = new List<Area>();
    public ICollection<Picket> Pickets { get; set; } = new List<Picket>();
    public ICollection<MainStorageCargo> MainStorageCargos { get; set; } = new List<MainStorageCargo>();

}
