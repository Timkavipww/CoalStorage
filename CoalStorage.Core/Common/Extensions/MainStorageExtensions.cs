namespace CoalStorage.Core.Common.Extensions;

public static class MainStorageExtensions
{
    public static MainStorageDTO ToDTO(this MainStorage mainStorage) => new MainStorageDTO
    {
        Id = mainStorage.Id,
        StorageName = mainStorage.StorageName,
        Areas = mainStorage.Areas.Select(a => a.ToDTO()).ToList(),
    };
    public static MainStorage ToEntity(this MainStorageDTO mainStorage) => new MainStorage
    {
        Id = mainStorage.Id,
        Areas = mainStorage.Areas.Select(a => a.ToEntity()).ToList(),
        StorageName = mainStorage.StorageName
    };
    public static void ToDTO(this List<MainStorage> mainStorages) => mainStorages.Select(u => u.ToDTO()).ToList();
    public static MainStorage ToEntity(this MainStorageCreateDTO mscDTO) => new MainStorage
    {
       StorageName = mscDTO.StorageName,
    };
}
