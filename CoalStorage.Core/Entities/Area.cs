namespace CoalStorage.Core.Entities;

public class Area : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [JsonIgnore]
    public string AreaName => Convert.ToString(MainStorageId * 100 + Id);

    /// <summary>
    /// binding with mainstorage
    /// </summary>
    [ForeignKey(nameof(MainStorage))]
    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; } = null!;

    //navigation property
    public ICollection<Picket> Pickets { get; set; } = new List<Picket>();
    
    public double TotalLoad => Pickets?.Sum(a => a.Load) ?? 0;



}