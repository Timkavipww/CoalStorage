namespace CoalStorage.Core.Interfaces;

public interface IStorageRepository
{
    Task<MainStorage> GetStorageByIdAsync(long storageId);
    Task<List<MainStorage>> GetAllStoragesAsync();
    Task RemoveStorageAsync(MainStorage mainStorage);
    Task CreateStorageAsync(MainStorage mainStorage);
    Task UpdateStorageAsync(MainStorage mainStorage);
    Task SaveChangesAsync();
}