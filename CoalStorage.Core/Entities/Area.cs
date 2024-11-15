namespace CoalStorage.Core.Entities;

public class Area : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string AreaRange { get; set; } // Example "101-104"


    public long MainStorageId { get; set; }  // ForeignKeywStorage
    public MainStorage MainStorage { get; set; }
    [JsonIgnore]
    public ICollection<MainStorageCargo> MainStorageCargos { get; set; } = new List<MainStorageCargo>();
    public ICollection<Picket> Pickets { get; set; } = new List<Picket>();
    public double TotalLoad => Pickets.Sum(p => p.Load);
    
}