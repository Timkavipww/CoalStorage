namespace CoalStorage.Core.Entities;

public class AreaPicket : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [ForeignKey(nameof(Area))]
    public long AreaId { get; set; }
    public Area Area { get; set; }

    [ForeignKey(nameof(Picket))]
    public long PicketId { get; set; }
    public Picket Picket { get; set; }
    public double Load { get; set; }

}