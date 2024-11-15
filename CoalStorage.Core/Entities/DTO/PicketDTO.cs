namespace CoalStorage.Core.Entities.DTO;

public class PicketDTO
{
    public required long Id { get; set; }
    public required long AreaId { get; set; }
    public required long MainStorageId { get; set; }
    [JsonIgnore]
    public string PicketName => (MainStorageId * 100 + Id).ToString();

}