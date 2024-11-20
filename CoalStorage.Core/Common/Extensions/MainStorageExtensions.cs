namespace CoalStorage.Core.Common.Extensions;

public static class MainStorageExtensions
{

    public static MainStorage ToEntity(this MainStorageDTO mainStorage) => new MainStorage
    {
        Id = mainStorage.Id,
        Areas = mainStorage.Areas.Select(a => a.ToEntity()).ToList(),
        StorageName = mainStorage.StorageName
    };
    public static void ToDTO(this List<MainStorage> mainStorages) => mainStorages.Select(u => u.ToDTO()).ToList();
  

    public static MainStorageDTO ToDTO(this MainStorage mainStorage)
    {
        if (mainStorage == null)
            return null;

        return new MainStorageDTO
        {
            Id = mainStorage.Id,
            StorageName = mainStorage.StorageName,
            Areas = mainStorage?.Areas?.Select(u => u.ToDTO()).ToList(),
            Pickets = mainStorage.Areas.SelectMany(a => a.Pickets).Select(p => new PicketDTO
            {
                Area = p.Area,
                Id = p.Id,
                AreaId = p.AreaId,
                Load = p.Load,
                   
            }).ToList(),
        };
    }
    public static MainStorage ToEntity(this MainStorageCreateDTO mainStorageCreateDTO) => new MainStorage
    {
        StorageName = mainStorageCreateDTO.StorageName,
    };
}
