namespace CoalStorage.Core.Entities.DTO;

public class AreaCreateDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public long Id { get; set; }
    public string AreaName => Convert.ToString(MainStorageId * 100 + Id);
    public long MainStorageId { get; set; }
    [NotMapped]
    public ICollection<Picket> Pickets { get; set; }
    //[JsonIgnore]
    public double TotalLoad => Pickets?.Sum(ap => ap.Load) ?? 0;

}
