using CoalStorage.Core.Entities.DTO;
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
            .Include(a => a.AreaPickets)
            .ThenInclude(ap => ap.Picket)
            .Where(a => a.MainStorageId == storageId)
            .ToListAsync();
    }

    public async Task<List<Area>> GetAllAreasAsync()
    {
        //return await _context.Areas.AsNoTracking()
        //    .Select(u => new Area
        //{
        //    AreaName = u.AreaName,
        //    Id = u.Id,
        //    MainStorageId = u.MainStorageId,
        //    Created = u.Created,
        //    CreatedBy = u.CreatedBy,
        //    LastModified = u.LastModified,
        //    LastModifiedBy = u.LastModifiedBy,
        //}).ToListAsync();
        return await _context.Areas.AsNoTracking().ToListAsync();
    }

    public async Task<Area> GetAreaByIdAsync(long areaId)
    {
        return await _context.Areas
            .Include(a => a.AreaPickets)
            .FirstOrDefaultAsync(a => a.Id == areaId);
    }

    public async Task RemoveAreaAsync(long areaId)
    {
        var area = await _context.Areas.FirstOrDefaultAsync(a => a.Id == areaId);

        _context.Remove(area);
    }

    public async Task CreteAreaAsync(Area area)
    {
        
        await _context.AddAsync(area);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAreaAsync(Area area)
    {
         _context.Update(area);
    }
}
