﻿using CoalStorage.Core.Entities.DTO;
namespace CoalStorage.Core.Common.Extensions;

public static class AreaExtensions
{
    public static Area toEntity(this AreaDTO areaDTO) => new Area
    {
        Id = areaDTO.Id,
        MainStorageId = areaDTO.MainStorageId,
        
    };
    public static AreaDTO toAreaDTO(this Area area) => new AreaDTO
    {
        Id = area.Id,
        MainStorageId = area.MainStorageId,
    };
}
