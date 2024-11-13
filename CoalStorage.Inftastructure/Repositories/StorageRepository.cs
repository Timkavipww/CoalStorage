using CoalStorage.Infrastructure.Data;

namespace CoalStorage.Infrastructure.Repositories;

public class StorageRepository : BaseRepository<MainStorage>, IStorageRepository
{
    private readonly AppDbContext _context;
    public StorageRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task AddAsync(MainStorageDTO entity)
    {
        entity.toEntity();
        await _context.AddAsync(entity);
    }
}
