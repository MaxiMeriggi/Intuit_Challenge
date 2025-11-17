namespace Intuit.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T payload);
        Task<T> UpdateAsync(T payload);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

    }
}
