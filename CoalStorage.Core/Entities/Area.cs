namespace CoalStorage.Core.Entities;

public class Area : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [JsonIgnore]
    public string AreaName => Convert.ToString(MainStorageId * 100 + Id);


    [ForeignKey(nameof(MainStorage))]
    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; }
    
    public ICollection<AreaPicket> AreaPickets { get; set; } = new List<AreaPicket>();
    public double TotalLoad => AreaPickets.Select(a => a.Load).Sum();



}