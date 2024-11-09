namespace CoalStorage.Core.Entities;

public class StoragePicket : BaseEntity
{
    public int StorageID { get; set; }
    public MainStorage MainStorage { get; set; } 

    public int PicketID { get; set; }
    public Picket Picket { get; set; }
}