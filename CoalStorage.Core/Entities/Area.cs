namespace CoalStorage.Core.Entities;

public class Area : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string AreaName => Convert.ToString(MainStorageId * 100 + Id);

    /// <summary>
    /// binding with mainstorage
    /// </summary>
    [ForeignKey(nameof(MainStorage))]
    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; } = null!;

    //navigation property
    public ICollection<Picket> Pickets { get; set; } = new List<Picket>();
    [JsonIgnore]
    
    public double TotalLoad => (Pickets?.Sum(u => u.Load) ?? 0);


}