namespace CoalStorage.Core.Entities;

public class Area : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string AreaName { get; set; }


    [ForeignKey(nameof(MainStorage))]
    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; }
    
    public ICollection<AreaPicket> AreaPickets { get; set; } = new List<AreaPicket>();
    public double TotalLoad {  get; set; }


}