namespace CoalStorage.Core.Interfaces;

public interface IPicketRepository : IBaseRepository<PicketDTO>
{
    Task<List<PicketDTO>> GetPicketsByStorageIdAsync(long storageId);
    Task<List<PicketDTO>> GetPicketsByAreaIdAsync(long areaId);
}