namespace CoalStorage.Core.Interfaces;

public interface IStorageRepository
{
    Task<MainStorage> GetStorageByIdAsync(int id);
    Task<IEnumerable<MainStorage>> GetAllStoragesAsync();
    Task AddStorageAsync(MainStorage storage);
    Task UpdateStorageAsync(MainStorage storage);
    Task DeleteStorageAsync(int id);
    Task SaveChangesAsync();
}