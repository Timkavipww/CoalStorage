namespace CoalStorage.Core.Common.Extensions;

public static class MainStorageExtensions
{
    public static MainStorage toEntity(this MainStorageDTO mainStorageDTO) => new MainStorage
    {
        Id = mainStorageDTO.Id,
        Areas = mainStorageDTO.Areas.Select(areaDto => areaDto.toEntity()).ToList(),
        Pickets = mainStorageDTO.Pickets.Select(picketsDto => picketsDto.toEntity()).ToList()
    };
}
