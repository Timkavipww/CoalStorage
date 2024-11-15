namespace CoalStorage.Core.Entities.DTO;

public class AreaDTO
{
    public long Id { get; set; }
    public string AreaName { get; set; }
    public long MainStorageId { get; set; }
    public List<PicketDTO> Pickets { get; set; }
    public double TotalLoad { get; set; }
}
