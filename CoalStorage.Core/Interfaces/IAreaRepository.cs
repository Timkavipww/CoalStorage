namespace CoalStorage.Core.Interfaces;

public interface IAreaRepository : IBaseRepository<Area>
{
    Task<List<Area>> GetAreasByStorageIdAsync(long storageId);
    Task<List<Area>> GetAreasByPicketIdAsync(long picketId);
}