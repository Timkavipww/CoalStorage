namespace CoalStorage.Core.Entities.DTO;

public class AreaDTO
{
    public long Id { get; set; }
    public string AreaName { get; set; }
    public long MainStorageId { get; set; }
    public List<PicketDTO> Pickets { get; set; }
    public ICollection<AreaPicket> AreaPickets { get; set; } = new List<AreaPicket>();
    public double TotalLoad => AreaPickets?.Sum(ap => ap.Load) ?? 0;
}
