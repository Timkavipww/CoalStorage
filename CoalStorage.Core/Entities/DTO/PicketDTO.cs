namespace CoalStorage.Core.Entities.DTO;

public class PicketDTO
{
    public long Id { get; set; }
    [JsonIgnore]
    public string PicketName => Convert.ToString(MainStorageId * 100 + Id);
    public long AreaId { get; set; }
    public long MainStorageId { get; set; }
}
