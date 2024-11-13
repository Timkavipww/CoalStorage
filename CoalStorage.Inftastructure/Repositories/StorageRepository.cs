using CoalStorage.Infrastructure.Data;

namespace CoalStorage.Infrastructure.Repositories;

public class StorageRepository : IStorageRepository
{
    private readonly AppDbContext _context;

    public StorageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MainStorage> GetStorageByIdAsync(int id)
    {
        return await _context.Storages
            .Include(s => s.Pickets)
            .Include(s => s.Areas)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<MainStorage>> GetAllStoragesAsync()
    {
        return await _context.Storages
            .Include(s => s.Pickets)
            .Include(s => s.Areas)
            .ToListAsync();
    }

    public async Task AddStorageAsync(MainStorage storage)
    {
        await _context.Storages.AddAsync(storage);
    }

    public async Task UpdateStorageAsync(MainStorage storage)
    {
        _context.Storages.Update(storage);
    }

    public async Task DeleteStorageAsync(int id)
    {
        var storage = await GetStorageByIdAsync(id);
        if (storage != null)
        {
            _context.Storages.Remove(storage);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}