using CoalStorage.Core.Entities;
using CoalStorage.Core.Entities.DTO;
namespace CoalStorage.Core.Common.Extensions;

public static class AreaExtensions
{
    public static Area ToEntity(this AreaDTO areaDTO) => new Area
    {
        Id = areaDTO.Id,
        AreaName = areaDTO.AreaName,
        Pickets = areaDTO.Pickets.Select(p => p.ToEntity()).ToList()
    };
    public static AreaDTO ToDTO(this Area area) => new AreaDTO
    {
        Id = area.Id,
        AreaName = area.AreaName,
        Pickets = area.Pickets.Select(p => p.ToDTO()).ToList(),
        TotalLoad = area.TotalLoad
    };
}
