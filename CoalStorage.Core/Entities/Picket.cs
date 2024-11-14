namespace CoalStorage.Core.Entities;

public class Picket : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string PicketName => (MainStorageId * 100 + Id).ToString(); // example "101"
    public long AreaId { get; set; } 
    public Area Area { get; set; }

    public long MainStorageId { get; set; }
    public MainStorage MainStorage { get; set; }

    public ICollection<MainStorageCargo> MainStorageCargos { get; set; } = new List<MainStorageCargo>();

}