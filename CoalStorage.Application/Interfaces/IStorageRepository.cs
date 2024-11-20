namespace CoalStorage.Application.Interfaces;

public interface IStorageRepository
{
    Task<MainStorage> GetStorageByIdAsync(long storageId);
    Task<List<MainStorage>> GetAllStoragesAsync();
    Task RemoveStorageAsync(long storageId);
    Task CreateStorageAsync(MainStorage mainStorage);
    Task UpdateStorageAsync(MainStorage mainStorage);
    Task SaveChangesAsync();
}