    using CoalStorage.Core.Entities;
    using CoalStorage.Core.Entities.DTO;
    namespace CoalStorage.Core.Common.Extensions;

    public static class AreaExtensions
    {
        public static Area ToEntity(this AreaDTO areaDTO) => new Area
        {
            Id = areaDTO.Id,
            AreaName = areaDTO.AreaName,
            MainStorageId = areaDTO.MainStorageId,
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
                Pickets = area.AreaPickets?
                    .Where(ap => ap.Picket != null)
                    .Select(ap => new PicketDTO
                    {
                        Id = ap.Picket.Id,
                        AreaId = area.Id,
                        MainStorageId = area.MainStorageId,
                    })
                    .ToList() ?? new List<PicketDTO>()
            };

            return areaDTO;

        }

        public static Area toEntity(this AreaCreateDTO areaCreate) => new Area
            {
                AreaName = areaCreate.AreaName,
                MainStorageId = areaCreate.MainStorageId,
                Created = DateTime.UtcNow,
                CreatedBy = "admin"
                
            };
    }
