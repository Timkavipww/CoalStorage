using CoalStorage.Core.Common.Extensions;
using CoalStorage.Core.Entities.DTO;
using CoalStorage.Core.Interfaces;
using CoalStorage.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoalStorage.Infrastructure.Repositories
{
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
}
