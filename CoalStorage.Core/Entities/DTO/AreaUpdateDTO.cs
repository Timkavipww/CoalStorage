namespace CoalStorage.Core.Entities.DTO;

public class AreaUpdateDTO {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public long Id { get; set; }
    public long MainStorageId { get; set; }
    [JsonIgnore]
    [NotMapped]
    public List<PicketDTO> Pickets { get; set; }
    public double TotalLoad => Pickets?.Sum(ap => ap.Load) ?? 0;

}
