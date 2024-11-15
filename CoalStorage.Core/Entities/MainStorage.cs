namespace CoalStorage.Core.Entities;

public class MainStorage : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string StorageName { get; set; }
    [JsonIgnore]
    public ICollection<Area> Areas { get; set; } = new List<Area>();
    [JsonIgnore]
    public ICollection<Picket> Pickets { get; set; } = new List<Picket>();
    [JsonIgnore]
    public ICollection<MainStorageCargo> MainStorageCargos { get; set; } = new List<MainStorageCargo>();


}
