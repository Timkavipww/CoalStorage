namespace CoalStorage.Infrastructure.Services;

public class StorageService
{
    private readonly IStorageRepository _storageRepository;
    private readonly IAreaRepository _areaRepository;
    private readonly IPicketRepository _picketRepository;

    public StorageService(
        IStorageRepository storageRepository,
        IAreaRepository areaRepository,
        IPicketRepository picketRepository)
    {
        _storageRepository = storageRepository;
        _areaRepository = areaRepository;
        _picketRepository = picketRepository;
    }

    public async Task AddPicketToStorageAsync(int storageId, Picket picket)
    {
        var storage = await _storageRepository.GetStorageByIdAsync(storageId);
        if (storage != null)
        {
            storage.Pickets.Add(picket);
            await _storageRepository.SaveChangesAsync();
        }
    }

    public async Task CreateAreaForConnectedPicketsAsync(int storageId, List<int> picketIds)
    {
        var storage = await _storageRepository.GetStorageByIdAsync(storageId);
        if (storage == null) return;

        var area = new Area();
        foreach (var picketId in picketIds)
        {
            var picket = await _picketRepository.GetPicketByIdAsync(picketId);
            if (picket != null)
            {
                area.Pickets.Add(picket);
            }
        }

        storage.Areas.Add(area);
        await _storageRepository.SaveChangesAsync();
    }
}
