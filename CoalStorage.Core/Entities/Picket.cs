namespace CoalStorage.Core.Entities;

public class Picket : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string PicketName => Convert.ToString(MainStorageId * 100 + Id);


    [ForeignKey(nameof(MainStorage))]
    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; }
    public double Load {  get; set; }

    public long AreaPicketId { get; set; }
    public AreaPicket AreaPicket { get; set; }


}