namespace CoalStorage.Core.Entities;

public class Picket : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [JsonIgnore]
    public long PicketName => Area.MainStorageId * 100 + Id;


    public double Load {  get; set; }

    /// <summary>
    /// binding with Area
    /// </summary>
    public long AreaId { get; set; }
    public Area Area { get; set; } = null!;

    public long MainStorageId => Area?.MainStorageId ?? 0; 


}