namespace CoalStorage.Core.Interfaces;

public interface IAreaRepository : IBaseRepository<AreaDTO>
{
    Task<List<AreaDTO>> GetAreasByStorageIdAsync(long storageId);
    Task<List<AreaDTO>> GetAreasByPicketIdAsync(long picketId);
}