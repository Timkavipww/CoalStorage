namespace CoalStorage.Core.Common.Extensions;

public static class PicketsExtension
{
    public static Picket toEntity(this PicketDTO picketDTO) => new Picket
    {
        Id = picketDTO.Id,
        AreaId = picketDTO.AreaId
    };
    public static PicketDTO toDTO(this Picket picket) => new PicketDTO
    {
        Id = picket.Id,
        AreaId = picket.AreaId,
    };
}
