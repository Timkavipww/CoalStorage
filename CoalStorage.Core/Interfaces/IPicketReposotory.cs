namespace CoalStorage.Core.Interfaces;

public interface IPicketRepository
{
    Task<List<Picket>> GetAllPicketsAsync();
    Task<List<Picket>> GetPicketsByStorageIdAsync(long storageId);
    Task<List<Picket>> GetPicketsByAreaIdAsync(long areaId);
    Task<Picket> GetPicketByIdAsync(long picketId);
    Task RemovePicketAsync(long PicketId);
    Task CreatePicketAsync(Picket picket);
    Task UpdatePicketAsync(Picket picket);
    Task SaveChangesAsync();
}