using CoalStorage.Core.Common.Extensions;
using CoalStorage.Core.Entities.DTO;

namespace CoalStorage.Infrastructure.Repositories;

public class StorageRepository : BaseRepository<MainStorageDTO>, IStorageRepository
{
    private readonly AppDbContext _context;

    public StorageRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<MainStorageDTO> GetStorageByIdAsync(long storageId)
    {
        return await _context.MainStorages
            .Where(ms => ms.Id == storageId)
            .Include(ms => ms.Areas)  // Чтобы подгрузить Areas вместе с MainStorage
            .Include(ms => ms.Pickets)
            .Select(ms => ms.toDTO())// Подгружаем Pickets (если это необходимо)
            .FirstOrDefaultAsync();
    }

    // Метод для получения всех складов
    public async Task<List<MainStorageDTO>> GetAllStoragesAsync()
    {
        return await _context.MainStorages
            .AsNoTracking()
            .Include(ms => ms.Areas)  // Загружаем Areas для всех складов
            .Include(ms => ms.Pickets)
            .Select(ms => ms.toDTO())// Подгружаем Pickets (если это необходимо)
            .ToListAsync();
    }

}