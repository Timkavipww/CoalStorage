namespace CoalStorage.Core.Interfaces;

public interface IAreaRepository
{
    Task<Area> GetByIdAsync(int storageId, int areaId);
    Task<IEnumerable<Area>> GetAllAsync(int storageId);
    Task AddAsync(int storageId, Area area);
    Task UpdateAsync(Area area);
    Task RemoveAsync(int storageId, int areaId);
    Task SaveChangesAsync();
}
