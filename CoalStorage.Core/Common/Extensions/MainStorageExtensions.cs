namespace CoalStorage.Core.Common.Extensions;

public static class MainStorageExtensions
{
    public static MainStorage toEntity(this MainStorageDTO mainStorageDTO) => new MainStorage
    {
        Id = mainStorageDTO.Id,
        StorageName = mainStorageDTO.StorageName
    };
    public static MainStorageDTO toDTO(this MainStorage mainStorage) => new MainStorageDTO
    {
        Id = mainStorage.Id,
        StorageName = mainStorage.StorageName
    };

}
