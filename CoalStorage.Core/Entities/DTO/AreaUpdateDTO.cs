namespace CoalStorage.Core.Entities.DTO;

public class AreaUpdateDTO {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public long Id { get; set; }
    public long MainStorageId { get; set; }
}
