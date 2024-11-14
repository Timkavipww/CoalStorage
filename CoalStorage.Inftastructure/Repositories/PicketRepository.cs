namespace CoalStorage.Infrastructure.Repositories;

public class PicketRepository : BaseRepository<Picket>, IPicketRepository
{
    private readonly AppDbContext _context;
    public PicketRepository(AppDbContext context) : base(context) { 
        _context = context;
    }

    public async Task<List<Picket>> GetPicketsByStorageIdAsync(long storageId)
    {
        return await _context.Pickets
            .AsNoTracking()
            .Where(p => p.MainStorageId == storageId)
            .ToListAsync();
    }

    public async Task<List<Picket>> GetPicketsByAreaIdAsync(long areaId)
    {
        return await _context.Pickets
            .AsNoTracking()
            .Where(p => p.AreaId == areaId)
            .ToListAsync();
    }
}
