namespace Intuit.Domain.Repositories
{
    public interface ISearchRepository<T> where T : class
    {
        Task<List<T>> SearchAsync(string text);
    }
}
