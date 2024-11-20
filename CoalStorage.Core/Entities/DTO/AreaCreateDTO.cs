namespace CoalStorage.Core.Entities.DTO;

public class AreaCreateDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public long Id { get; set; }
    public string AreaName { get; set; }
    public long MainStorageId { get; set; }
    public double TotalLoad { get; set; }
}
