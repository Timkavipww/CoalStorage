namespace CoalStorage.Core.Entities;

public class MainStorage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string StorageName { get; set; }
    public ICollection<Area> Areas { get; set; }
    public List<Picket> Pickets { get; set; }

}
