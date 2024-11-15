namespace CoalStorage.Core.Entities.DTO;

public class AreaDTO
{
    public required long Id { get; set; }
    [JsonIgnore]
    public string AreaName => (MainStorageId * 100 + Id).ToString();
    public required long MainStorageId { get; set; }
    public List<PicketDTO> Pickets { get; set; }
}
