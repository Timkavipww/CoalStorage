namespace CoalStorage.Core.Common.Extensions;

public static class AreaPicketExtensions
{
    public static AreaPicketDTO ToDTO(this AreaPicket areaPicket)
    {
        if (areaPicket == null)
            return null;

        return new AreaPicketDTO
        {
            Id = areaPicket.Id,
            AreaId = areaPicket.AreaId,
            PicketId = areaPicket.PicketId
        };
    }
}