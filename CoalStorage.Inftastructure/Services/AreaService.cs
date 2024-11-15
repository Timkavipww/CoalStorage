namespace CoalStorage.Infrastructure.Services;

public class AreaService
{
    private readonly PicketService _picketService;
    private readonly ILogger<AreaService> _logger;

    public AreaService(PicketService picketService, ILogger<AreaService> logger)
    {
        _picketService = picketService;
        _logger = logger;
    }

    public bool CheckIfAdjacent(Picket picket1, Picket picket2)
    {
        return _picketService.isAdjacentTo(picket1, picket2);
    }

    /// <summary>
    /// Validate and CreateArea 
    /// </summary>
    /// <param name="pickets"></param>
    /// <param name="existingAreas"></param>
    /// <param name="newArea"></param>
    /// <returns></returns>
    public bool ValidateAndCreateArea(List<Picket> pickets, List<Area> existingAreas, out Area newArea)
    {
        newArea = null;

        if (pickets.Any())
        {
            for (int i = 1; i < pickets.Count; i++)
            {
                if (!_picketService.isAdjacentTo(pickets[i - 1], pickets[i]))
                {
                    return false;
                }
            }
        }

        foreach (var area in existingAreas)
        {
            // Пересечение с другой площадкой
            if (IsOverlappingWith(area, new Area { Pickets = pickets, Id = area.Id }))
            {
                return false;
            }
        }

        
        newArea = new Area
        {
            Pickets = pickets
        };
        _logger.LogInformation("Новая площадка создана. Площадка разбита на следующие пикеты: {PicketsIds} в {Time}",
        newArea.Id, DateTime.UtcNow);

        return true; 
    }

    public bool IsOverlappingWith(Area area, Area otherArea)
    {
        //проверяем на пересечение с другой площадкой
        foreach (var picket in area.Pickets)
        {
            if (otherArea.Pickets.Contains(picket))
            {
                return true;
            }
        }
        return false;
    }
}
