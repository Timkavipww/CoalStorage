using CoalStorage.Core.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoalStorage.Core.Interfaces
{
    public interface IStorageRepository : IBaseRepository<MainStorage>
    {
        Task AddAsync(MainStorage entity);
    }
}
