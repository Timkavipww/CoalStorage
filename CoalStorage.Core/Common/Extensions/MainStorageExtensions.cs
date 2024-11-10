using CoalStorage.Core.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CoalStorage.Core.Common.Extensions
{
    public static class MainStorageExtensions
    {
        public static MainStorage toEntity(this MainStorageDTO mainStorageDTO)
        {
            if (mainStorageDTO == null) return null;

            return new MainStorage { Id = mainStorageDTO.Id, Created = DateTimeOffset.UtcNow, CreatedBy = "Admin" };
        }
    }
}
