namespace CoalStorage.Core.Interfaces
{
    public interface IStorageRepository : IBaseRepository<MainStorage>
    {
        Task AddAsync(MainStorage entity);
    }
}
