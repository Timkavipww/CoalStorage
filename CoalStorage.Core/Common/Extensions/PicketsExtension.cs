namespace CoalStorage.Core.Common.Extensions;

public static class PicketsExtension
{
    public static PicketDTO ToDTO(this Picket picket) => new PicketDTO
    {
        AreaId = picket.AreaId,
        Id = picket.Id,
        Load = picket.Load,
    };
    public static Picket ToEntity(this PicketDTO picketDTO) => new Picket
    {
        AreaId = picketDTO.AreaId,
        Id = picketDTO.Id,
        Load = picketDTO.Load,
    };
}
