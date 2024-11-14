namespace CoalStorage.Infrastructure.Repositories;

public class AreaRepository : BaseRepository<Area>, IAreaRepository
{
    private readonly AppDbContext _context;

    public AreaRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Area>> GetAreasByStorageIdAsync(long storageId)
    {
        return await _context.Areas
            .Where(a => a.MainStorageId == storageId)  // Используем связь через MainStorageId
            .ToListAsync();
    }

    // Метод для получения всех площадок, где находится пикет
    public async Task<List<Area>> GetAreasByPicketIdAsync(long picketId)
    {
        return await _context.Areas
            .Where(a => a.Pickets.Any(p => p.Id == picketId))  // Используем связь через Pickets
            .ToListAsync();
    }
}
