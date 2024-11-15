namespace CoalStorage.Core.Entities;

public class Area : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public  long Id { get; set; }
    [JsonIgnore]
    public string AreaRange { get; set; } // Example "101-104"
    public long MainStorageId { get; set; }  // ForeignKeywStorage
    public MainStorage MainStorage { get; set; }
    [JsonIgnore]
    public ICollection<MainStorageCargo> MainStorageCargos { get; set; } = new List<MainStorageCargo>();
    [JsonIgnore]
    public ICollection<Picket> Pickets { get; set; } = new List<Picket>();
    [JsonIgnore]
    public double TotalLoad => Pickets.Sum(p => p.Load);
    
}