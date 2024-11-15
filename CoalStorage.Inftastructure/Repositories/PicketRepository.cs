using CoalStorage.Core.Common.Extensions;
using CoalStorage.Core.Entities.DTO;

namespace CoalStorage.Infrastructure.Repositories;

public class PicketRepository : BaseRepository<PicketDTO>, IPicketRepository
{
    private readonly AppDbContext _context;
    public PicketRepository(AppDbContext context) : base(context) { 
        _context = context;
    }

    public async Task<List<PicketDTO>> GetPicketsByStorageIdAsync(long storageId)
    {
        return await _context.Pickets
            .AsNoTracking()
            .Where(p => p.MainStorageId == storageId)
            .Select(u => u.toDTO())
            .ToListAsync();
    }

    public async Task<List<PicketDTO>> GetPicketsByAreaIdAsync(long areaId)
    {
        return await _context.Pickets
            .AsNoTracking()
            .Where(p => p.AreaId == areaId)
            .Select(u => u.toDTO())
            .ToListAsync();
    }
}
