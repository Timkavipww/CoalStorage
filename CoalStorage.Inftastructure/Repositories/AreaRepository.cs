
using CoalStorage.Core.Common.Extensions;

namespace CoalStorage.Infrastructure.Repositories;

public class AreaRepository : BaseRepository<AreaDTO>, IAreaRepository
{
    private readonly AppDbContext _context;

    public AreaRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<AreaDTO>> GetAreasByStorageIdAsync(long storageId)
    {
        return await _context.Areas
            .Where(a => a.MainStorageId == storageId)
            .Select(u => u.toDTO())// Используем связь через MainStorageId
            .ToListAsync();
    }

    // Метод для получения всех площадок, где находится пикет
    public async Task<List<AreaDTO>> GetAreasByPicketIdAsync(long picketId)
    {
        return await _context.Areas
            .Where(a => a.Pickets.Any(p => p.Id == picketId))
            .Select(u => u.toDTO())// Используем связь через Pickets
            .ToListAsync();
    }
}
