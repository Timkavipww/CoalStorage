namespace CoalStorage.Infrastructure.Repositories;

public class StorageRepository : IStorageRepository
{
    private readonly AppDbContext _context;

    public StorageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MainStorage> GetStorageByIdAsync(long storageId)
    {
        return await _context.MainStorages
            .AsNoTracking()
            .Include(storage => storage.Areas)
                .ThenInclude(area => area.Pickets)
                    .FirstOrDefaultAsync();
            
    }

    // Метод для получения всех складов
    public async Task<List<MainStorage>> GetAllStoragesAsync()
    {
        return await _context.MainStorages
            .AsNoTracking()
            .Include(storage => storage.Areas)
                .ThenInclude(area => area.Pickets)  // Загружаем пикеты для каждой области
                    .ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task RemoveStorageAsync(MainStorage mainStorage)
    {
        if (mainStorage != null)
        {
        _context.Remove(mainStorage);
        }
    }

}