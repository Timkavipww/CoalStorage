using CoalStorage.Core.Entities.DTO;

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
