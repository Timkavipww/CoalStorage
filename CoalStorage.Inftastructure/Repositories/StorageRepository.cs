namespace CoalStorage.Infrastructure.Repositories;

public class StorageRepository : BaseRepository<MainStorage>, IStorageRepository
{
    private readonly AppDbContext _context;

    public StorageRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<MainStorage> GetStorageByIdAsync(long storageId)
    {
        return await _context.MainStorages
            .Where(ms => ms.Id == storageId)
            .Include(ms => ms.Areas)  // Чтобы подгрузить Areas вместе с MainStorage
            .Include(ms => ms.Pickets)  // Подгружаем Pickets (если это необходимо)
            .FirstOrDefaultAsync();
    }

    // Метод для получения всех складов
    public async Task<List<MainStorage>> GetAllStoragesAsync()
    {
        return await _context.MainStorages
            .Include(ms => ms.Areas)  // Загружаем Areas для всех складов
            .Include(ms => ms.Pickets)  // Подгружаем Pickets (если это необходимо)
            .ToListAsync();
    }
}