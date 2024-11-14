namespace CoalStorage.Core.Entities.DTO;

public class MainStorageDTO
{
    
    public long Id { get; set; }
    public List<PicketDTO> Pickets { get; set; } = new List<PicketDTO>();
    public List<AreaDTO> Areas { get; set; } = new List<AreaDTO>();
}
