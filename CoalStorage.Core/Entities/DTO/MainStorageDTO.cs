namespace CoalStorage.Core.Entities.DTO;

public class MainStorageDTO
{
    
    public long Id { get; set; }
    public string StorageName { get; set; }

    public ICollection<AreaDTO> Areas { get; set; } = new List<AreaDTO>();
    public ICollection<PicketDTO> Pickets { get; set; } = new List<PicketDTO>();
}
