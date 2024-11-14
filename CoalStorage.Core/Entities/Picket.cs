namespace CoalStorage.Core.Entities;

public class Picket : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string PicketName { get; set; } // example "101"

}
