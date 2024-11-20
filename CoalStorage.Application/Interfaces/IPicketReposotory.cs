namespace CoalStorage.Application.Interfaces;

public interface IPicketRepository
{
    Task<List<Picket>> GetPicketsByAreaIdAsync(long storageId, long areaId);
    Task<Picket> GetPicketByIdAsync(long storageId, long areaId, long picketId);
    Task RemovePicketAsync(long storageId, long AreaId, long picketId);
    Task CreatePicketAsync(long storageId, long AreaId, Picket picket);
    Task UpdatePicketAsync(long storageId, long AreaId, Picket picket);
    Task SaveChangesAsync();
}