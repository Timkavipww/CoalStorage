namespace CoalStorage.Core.Services;

public class MainStorageService
{
    private readonly AreaService _areaService;
    private readonly PicketService _picketService;
    private readonly List<Area> _existingAreas;

    public MainStorageService(AreaService areaService)
    {
        _areaService = areaService;
        _existingAreas = new List<Area>();
    }
    /// <summary>
    /// Creating with validating
    /// </summary>
    /// <param name="pickets"></param>
    /// <returns></returns>
    public bool CreateArea(List<Picket> pickets)
    {
        Area newArea;
        if(_areaService.ValidateAndCreateArea(pickets, _existingAreas, out newArea))
        {
            _existingAreas.Add(newArea);
            return true;
        }
        return false;
    }
}
