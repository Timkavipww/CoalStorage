namespace CoalStorage.Core.Entities.DTO;

public class PicketDTO
{
    public long Id { get; set; }
    public long AreaId { get; set; }
    public long MainStorageId { get; set; }
    public string PicketName => (MainStorageId * 100 + Id).ToString();

}