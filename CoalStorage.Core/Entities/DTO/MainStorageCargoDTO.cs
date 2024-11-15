namespace CoalStorage.Core.Entities.DTO;

public class MainStorageCargoDTO
{
    public long Id { get; set; }
    public double Weight { get; set; }
    public long MainStorageId { get; set; }
    public long AreaId { get; set; }
    public long PicketId { get; set; }
}
