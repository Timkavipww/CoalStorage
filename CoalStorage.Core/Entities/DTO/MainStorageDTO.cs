namespace CoalStorage.Core.Entities.DTO;

public class MainStorageDTO
{
    
    public required long Id { get; set; }
    public string StorageName { get; set; }
    [JsonIgnore]
    public ICollection<AreaDTO> Areas { get; set; } = new List<AreaDTO>();
    [JsonIgnore]
    public ICollection<PicketDTO> Pickets { get; set; } = new List<PicketDTO>();
}
