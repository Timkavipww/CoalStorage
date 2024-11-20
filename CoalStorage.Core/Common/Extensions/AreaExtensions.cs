using CoalStorage.Core.Entities;

namespace CoalStorage.Core.Common.Extensions;

public static class AreaExtensions
    {
        public static Area ToEntity(this AreaDTO areaDTO) => new Area
        {
            Id = areaDTO.Id,
            MainStorageId = areaDTO.MainStorageId,
            Pickets = areaDTO.Pickets
                .ToList()
                .Select(p => p.ToEntity())
                .ToList()
        };


        public static AreaDTO ToDTO(this Area area)
        {
            if (area == null)
                return null;

        var areaDTO = new AreaDTO
        {
            Id = area.Id,
            AreaName = area.AreaName,
            MainStorageId = area.MainStorageId,
            Pickets = area.Pickets
                .ToList()
                .Select(a => a.ToDTO())
                .ToList()

        };

            return areaDTO;

        }

        public static Area toEntity(this AreaCreateDTO areaCreate) => new Area
            {
                MainStorageId = areaCreate.MainStorageId,
                Created = DateTime.UtcNow,
                CreatedBy = "admin"
                
            };
    }
