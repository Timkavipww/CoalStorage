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

    public async Task<List<Picket>> GetAllPicketsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Picket> GetPicketByIdAsync(long picketId)
    {
        throw new NotImplementedException();
    }

    public async Task RemovePicketAsync(long PicketId)
    {
        throw new NotImplementedException();
    }

    public async Task CreatePicketAsync(Picket picket)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePicketAsync(Picket picket)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
