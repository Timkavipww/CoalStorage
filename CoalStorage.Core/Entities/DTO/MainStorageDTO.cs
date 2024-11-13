namespace CoalStorage.Core.Entities.DTO;

public class MainStorageDTO
{
    public int Id { get; set; }
    public List<PicketDTO> Pickets { get; set; } = new List<PicketDTO>();
    public List<AreaDTO> Areas { get; set; } = new List<AreaDTO>();
}
