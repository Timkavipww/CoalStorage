namespace CoalStorage.Core.Common.Extensions;

public static class PicketsExtension
{
  
    public static Picket ToEntity(this PicketDTO picketDTO) => new Picket
    {
        Id = picketDTO.Id,
        Area = picketDTO.Area,
        AreaId = picketDTO.AreaId,
        Load = picketDTO.Load,
    };
    public static PicketDTO ToDTO(this Picket picket)
    {
        if (picket == null)
            return null;

        return new PicketDTO
        {
            Id = picket.Id,
            Area = picket.Area,
            AreaId = picket.AreaId,
            Load = picket.Load,
        };
    }
}
