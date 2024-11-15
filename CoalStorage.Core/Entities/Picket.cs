namespace CoalStorage.Core.Entities;

public class Picket : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    /// <summary>
    /// LOAD OF PICKET
    /// </summary>
    public double Load { get; set; }
    /// <summary>
    /// PICKET NAME EXAMPLE "101" = MainStoragId * 100 + Id
    /// </summary>
    [NotMapped]
    public string PicketName => Convert.ToString(MainStorageId * 100 + Id); // example "101"


    /// <summary>
    /// FOREIGN KEY AREA
    /// </summary>
    [ForeignKey(nameof(Area))]
    public long AreaId { get; set; }
    public Area Area { get; set; }

    /// <summary>
    /// FOREIGN KEY MAINSTORAGE
    /// </summary>
    [ForeignKey(nameof(MainStorage))]
    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; }
}