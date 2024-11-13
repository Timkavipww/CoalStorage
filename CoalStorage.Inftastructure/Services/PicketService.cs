namespace CoalStorage.Infrastructure.Services;

public class PicketService
{
    /// <summary>
    /// Single Adjacent Check
    /// </summary>
    /// <param name="picket1"></param>
    /// <param name="picket2"></param>
    /// <returns></returns>
    public bool isAdjacentTo(Picket picket1, Picket picket2)
    {
        return Math.Abs(picket1.Id - picket2.Id) == 1;
    }
    /// <summary>
    /// Multiple Adjacent Check
    /// </summary>
    /// <param name="pickets"></param>
    /// <returns></returns>
    public bool ArePicketsAdjacent(List<Picket> pickets)
    {
        for (int i = 1; i < pickets.Count; i++)
        {
            if (!isAdjacentTo(pickets[i - 1], pickets[i]))
            {
                return false;
            }
        }
        return true;
    }
}
