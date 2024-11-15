namespace CoalStorage.Core.Entities;

public class Area : BaseAuditableEntity
{
    /// <summary>
    /// KEY
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    /// <summary>
    /// FOREIGN KEY MAINSTORAGE
    /// </summary>
    [ForeignKey(nameof(MainStorage))]
    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; }


    public ICollection<Picket> Pickets { get; set; } = new List<Picket>();

    [NotMapped]
    public double TotalLoad => Pickets.Sum(p => p.Load);

    public string AreaName { get; set; }

}