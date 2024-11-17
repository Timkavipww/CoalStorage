namespace CoalStorage.Core.Common.Extensions;

public static class PicketsExtension
{
  
    public static Picket ToEntity(this PicketDTO picketDTO) => new Picket
    {
        Id = picketDTO.Id,
        MainStorageId = picketDTO.MainStorageId,
    };
    public static PicketDTO ToDTO(this Picket picket)
    {
        if (picket == null)
            return null;

        return new PicketDTO
        {
            Id = picket.Id,
            MainStorageId = picket.MainStorageId,
            AreaId = picket.MainStorageId, // Сформированное имя
        };
    }
}
