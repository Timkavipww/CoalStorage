using System.Runtime.InteropServices;

namespace CoalStorage.Infrastructure.Repositories;

public class AreaRepository : IAreaRepository
{
    private readonly AppDbContext _context;

    public AreaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Area>> GetAreasByStorageIdAsync(long storageId)
    {
        return await _context.Areas
            .Where(a => a.MainStorageId == storageId)
            .ToListAsync();
    }

    public async Task<Area> GetAreaByPicketIdAsync(long picketId)
    {
        var picket = await _context.Pickets.FirstOrDefaultAsync(u => u.Id == picketId);
        var area = _context.AreaPickets.Select(u => new Area
        {
            
        });

        return (Area)area;

    }


    public async Task<List<Area>> GetAllAreasAsync()
    {
        return await _context.Areas.AsNoTracking().Select(u => new Area
        {
            AreaName = u.AreaName,
            Id = u.Id,
            MainStorageId = u.MainStorageId,
            Created = u.Created,
            CreatedBy = u.CreatedBy,
        }).ToListAsync();
    }

    public async Task<Area> GetAreaByIdAsync(long areaId)
    {
        await Task.Delay(1000);
        throw new NotImplementedException();
    }

    public async Task RemoveAreaAsync(long areaId)
    {
        await Task.Delay(1000);
        throw new NotImplementedException();
    }

    public async Task CreteAreaAsync(List<Picket> pickets)
    {
        await Task.Delay(1000);
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
