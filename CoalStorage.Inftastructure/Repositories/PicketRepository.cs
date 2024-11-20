using CoalStorage.Core.Common.Extensions;
using CoalStorage.Core.Entities.DTO;

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
        return await _context
            .Areas
            .AsNoTracking()
            .Include(a => a.AreaPickets)
                .ThenInclude(ap => ap.Picket)
            .Where(a => a.MainStorageId == storageId && a.Id == areaId)
            .SelectMany(a => a.AreaPickets)
            .Where(ap => ap.PicketId == picketId)
            .Select(ap => ap.Picket)
            .FirstOrDefaultAsync();


    }

    public Task<List<Picket>> GetPicketsByAreaIdAsync(long storageId, long areaId)
    {
        throw new NotImplementedException();
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
