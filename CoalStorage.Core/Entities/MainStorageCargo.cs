namespace CoalStorage.Core.Entities;

public class MainStorageCargo : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public double Weight { get; set; }


    /// <summary>
    /// MainStorage ForeignKey
    /// </summary>
    [ForeignKey(nameof(MainStorage))]
    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; }



    /// <summary>
    /// Area Foreign Key
    /// </summary>
    [ForeignKey(nameof(Area))]
    public long AreaId { get; set; }
    public Area Area { get; set; }


    /// <summary>
    /// PicketForeignKey
    /// </summary>

    [ForeignKey(nameof(Picket))]
    public long PicketId { get; set; }
    public Picket Picket { get; set; }

}