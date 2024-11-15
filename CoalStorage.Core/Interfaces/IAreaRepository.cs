namespace CoalStorage.Core.Interfaces;

public interface IAreaRepository
{
    Task<List<Area>> GetAreasByStorageIdAsync(long storageId);
    Task<Area> GetAreaByPicketIdAsync(long picketId);
    Task<List<Area>> GetAllAreasAsync();
    Task<Area> GetAreaByIdAsync(long areaId);
    Task RemoveAreaAsync(long areaId);
    Task CreteAreaAsync(List<Picket> pickets);
    Task SaveChangesAsync();
<<<<<<< HEAD

=======
>>>>>>> 1b68ea92c4ce3538ac7461be9ea1fc9988f24133
}