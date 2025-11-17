namespace Intuit.Domain.Repositories
{
    public interface ICreateOnlyRepository<T> where T : class
    {
        Task<T> CreateOnlyAsync(T payload);

    }
}
