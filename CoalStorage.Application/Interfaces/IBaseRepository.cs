namespace CoalStorage.Application.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetByIdAsync(long id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(long id);
    Task SaveChangesAsync();
}
