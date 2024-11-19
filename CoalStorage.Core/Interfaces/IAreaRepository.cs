namespace CoalStorage.Core.Interfaces;

public interface IAreaRepository
{
    Task<List<Area>> GetAreasByStorageIdAsync(long storageId);
    Task<List<Area>> GetAllAreasAsync();
    Task<Area> GetAreaByIdAsync(long areaId);
    Task RemoveAreaAsync(long areaId);
    Task UpdateAreaAsync(Area area);
    Task CreteAreaAsync(Area area);
    Task SaveChangesAsync();
}