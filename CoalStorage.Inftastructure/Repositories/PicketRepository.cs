namespace CoalStorage.Infrastructure.Repositories;

public class PicketRepository : IPicketRepository
{
    private readonly AppDbContext _context;
    public PicketRepository(AppDbContext context)
    { 
        _context = context;
    }

    public Task CreatePicketAsync(long storageId, long AreaId, Picket picket)
    {
        throw new NotImplementedException();
    }

    public async Task<Picket> GetPicketByIdAsync(long storageId, long areaId, long picketId)
    {
        
        throw new NotImplementedException();


    }

    public async Task<List<Picket>> GetPicketsByAreaIdAsync(long storageId, long areaId)
    {
        return await _context
            .Pickets
            .AsNoTracking()
            .Where(a => a.MainStorageId == storageId && a.AreaId == areaId)
                .AsSplitQuery()
                .ToListAsync();
    }

    public Task RemovePicketAsync(long storageId, long AreaId, long picketId)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdatePicketAsync(long storageId, long AreaId, Picket picket)
    {
        throw new NotImplementedException();
    }
}
