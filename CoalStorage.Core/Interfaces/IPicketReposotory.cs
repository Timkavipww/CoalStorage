namespace CoalStorage.Core.Interfaces;

public interface IPicketRepository
{
    Task<Picket> GetPicketByIdAsync(int id);
    Task<IEnumerable<Picket>> GetAllPicketsAsync();
    Task AddPicketAsync(Picket picket);
    Task UpdatePicketAsync(Picket picket);
    Task DeletePicketAsync(int id);
    Task SaveChangesAsync();
}