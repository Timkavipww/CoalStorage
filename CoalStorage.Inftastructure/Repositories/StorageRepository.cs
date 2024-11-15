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
                    .FirstOrDefaultAsync(u => u.Id == storageId);

            
    }

    public async Task<List<MainStorage>> GetAllStoragesAsync()
    {
        return await _context.MainStorages
            .AsNoTracking()
            .Include(storage => storage.Areas)
                .ThenInclude(area => area.Pickets) 
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

    public async Task CreateStorageAsync(MainStorage mainStorage)
    {
        await _context.AddAsync(mainStorage);
    }



    public async Task UpdateStorageAsync(MainStorage mainStorage)
    {
        _context.Update(mainStorage);

    }
}