namespace CoalStorage.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AppDbContext _context;

        public AreaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Area> GetByIdAsync(int storageId, int areaId)
        {
            return await _context.Areas
                .Where(a => a.MainStorage.Id == storageId && a.Id == areaId)
                .Include(a => a.Pickets) // загрузка связанных пикетов
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Area>> GetAllAsync(int storageId)
        {
            return await _context.Areas
                .Where(a => a.MainStorage.Id == storageId)
                .Include(a => a.Pickets)
                .ToListAsync();
        }

        public async Task AddAsync(int storageId, Area area)
        {
            var storage = await _context.Storages.FindAsync(storageId);
            if (storage != null)
            {
                storage.Areas.Add(area);
            }
        }

        public async Task UpdateAsync(Area area)
        {
            _context.Areas.Update(area);
        }

        public async Task RemoveAsync(int storageId, int areaId)
        {
            var area = await GetByIdAsync(storageId, areaId);
            if (area != null)
            {
                _context.Areas.Remove(area);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
