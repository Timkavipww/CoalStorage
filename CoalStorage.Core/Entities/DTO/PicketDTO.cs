namespace CoalStorage.Core.Entities.DTO;

public class PicketDTO
{
    public long Id { get; set; }
    public long PicketName => Area.MainStorageId * 100 + Id;

    public long AreaId { get; set; }
    public double Load { get; set; }
    [NotMapped]
    public Area Area { get; set; }
    public long MainStorageId => Area?.MainStorageId ?? 0;


}
