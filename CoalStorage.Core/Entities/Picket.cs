namespace CoalStorage.Core.Entities;

public class Picket : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }


    /// <summary>
    /// binding with Area
    /// </summary>
    public long AreaId { get; set; }
    public Area Area { get; set; } = null!;
    public double Load {  get; set; }

    public long MainStorageId { get; set; }
    [JsonIgnore]

    public long PicketName => (int)((Area.MainStorageId * 100) + Id);


}