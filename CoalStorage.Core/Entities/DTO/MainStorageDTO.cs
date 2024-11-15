namespace CoalStorage.Core.Entities.DTO;

public class MainStorageDTO
{
    public long Id { get; set; }
    public string StorageName { get; set; }
    public List<AreaDTO> Areas { get; set; }
}
