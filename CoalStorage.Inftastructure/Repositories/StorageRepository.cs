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
                .ThenInclude(area => area.AreaPickets)
                    .ThenInclude(ap => ap.Picket) // Подгружаем Picket
            .AsSplitQuery()
            .FirstOrDefaultAsync(u => u.Id == storageId);
    }

    public async Task<List<MainStorage>> GetAllStoragesAsync()
    {
        return await _context.MainStorages
            .AsNoTracking()
            .Include(storage => storage.Areas)
                .ThenInclude(area => area.AreaPickets)
                    .ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task RemoveStorageAsync(long storageId)
    {
        try
        {
        var storage = await _context.MainStorages.FirstOrDefaultAsync(u => u.Id == storageId);
        _context.Remove(storage);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        


    }

    public async Task CreateStorageAsync(MainStorage mainStorage)
    {
        await _context.AddAsync(mainStorage);
    }



    public async Task UpdateStorageAsync(MainStorage mainStorage)
    {
        await Task.Delay(1000);

        _context.Update(mainStorage);

    }
}