namespace CoalStorage.Core.Interfaces;

public interface IStorageRepository : IBaseRepository<MainStorageDTO>
{
    Task<MainStorageDTO> GetStorageByIdAsync(long storageId);
    Task<List<MainStorageDTO>> GetAllStoragesAsync();
}