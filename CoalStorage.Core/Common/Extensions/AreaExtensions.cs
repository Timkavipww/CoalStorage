namespace CoalStorage.Core.Common.Extensions;

public static class AreaExtensions
    {
        public static Area ToEntity(this AreaDTO areaDTO) => new Area
        {
            Id = areaDTO.Id,
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
                    .Select(p => new PicketDTO
                    {
                        Id = p.Picket.Id,
                        AreaId = area.Id,
                        MainStorageId = area.MainStorageId,
                        Load = p.Load
                    })
                    .ToList() ?? new List<PicketDTO>()
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
