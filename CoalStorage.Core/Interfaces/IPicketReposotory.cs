namespace CoalStorage.Core.Interfaces;

public interface IPicketRepository : IBaseRepository<Picket>
{
    Task<List<Picket>> GetPicketsByStorageIdAsync(long storageId);
    Task<List<Picket>> GetPicketsByAreaIdAsync(long areaId);
}