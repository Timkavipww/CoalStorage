using CoalStorage.Core.Common.Extensions;

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

    // Метод для добавления пикета в склад
    public async Task AddPicketToStorageAsync(long storageId, Picket picket)
    {
        var storage = await _storageRepository.GetStorageByIdAsync(storageId);
        if (storage != null)
        {
            // Добавляем пикет в склад
            storage.Pickets.Add(picket);
            await _storageRepository.SaveChangesAsync();
        }
    }

    // Метод для создания новой площади, связанной с несколькими пикетами
    public async Task CreateAreaForConnectedPicketsAsync(long storageId, List<long> picketIds)
    {
        var storage = await _storageRepository.GetStorageByIdAsync(storageId);
        if (storage == null) return;

        // Создаём новую площадь
        var area = new Area { MainStorageId = storageId };

        foreach (var picketId in picketIds)
        {
            var picket = await _picketRepository.GetPicketByIdAsync(picketId);

            var areaPicket = new AreaPicket
            {
                AreaId = area.Id, // Указываем Id площадки
                PicketId = picket.Id, // Указываем Id пикета
                Area = area, // Ссылаемся на объект площадки
                Picket = picket // Ссылаемся на объект пикета
            };
            if (picket != null)
            {
                // Добавляем пикет в площадь
                area.AreaPickets.Add(areaPicket);
            }
        }

        // Добавляем площадь к складу
        storage.Areas.Add(area);

        // Сохраняем изменения в базе данных
        await _storageRepository.SaveChangesAsync();
    }

    // Метод для получения всех пикетов на складе
    public async Task<List<Picket>> GetPicketsByStorageAsync(long storageId)
    {
        return await _picketRepository.GetPicketsByStorageIdAsync(storageId);
    }

    // Метод для получения всех пикетов на площади
    public async Task<List<Picket>> GetPicketsByAreaAsync(long areaId)
    {
        return await _picketRepository.GetPicketsByAreaIdAsync(areaId);
    }

    // Метод для создания связи между складом и площадкой (например, если у вас есть необходимость связывать их отдельно)
    public async Task LinkAreaToStorageAsync(long storageId, long areaId)
    {
        var storage = await _storageRepository.GetStorageByIdAsync(storageId);
        if (storage == null) return;

        var area = await _areaRepository.GetAreaByIdAsync(areaId);
        if (area != null && !storage.Areas.Contains(area))
        {
            storage.Areas.Add(area);
            await _storageRepository.SaveChangesAsync();
        }
    }
}
