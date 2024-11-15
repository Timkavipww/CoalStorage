namespace CoalStorage.Core.Common.Extensions;

public static class PicketsExtension
{
    public static PicketDTO ToDTO(this Picket picket) => new PicketDTO
    {
        AreaId = picket.AreaId,
        Id = picket.Id,
        Load = picket.Load,
<<<<<<< HEAD
=======
        PicketName = picket.PicketName,
>>>>>>> 1b68ea92c4ce3538ac7461be9ea1fc9988f24133
    };
    public static Picket ToEntity(this PicketDTO picketDTO) => new Picket
    {
        AreaId = picketDTO.AreaId,
        Id = picketDTO.Id,
        Load = picketDTO.Load,
    };
}
