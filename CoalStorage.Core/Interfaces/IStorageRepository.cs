namespace CoalStorage.Core.Interfaces;

public interface IStorageRepository : IBaseRepository<MainStorage>
{
    Task<MainStorage> GetStorageByIdAsync(long storageId);
    Task<List<MainStorage>> GetAllStoragesAsync();
}