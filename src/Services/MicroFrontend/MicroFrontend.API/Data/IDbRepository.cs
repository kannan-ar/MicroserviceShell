namespace MicroFrontend.API.Data
{
    public interface IDbRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task Add(T entity);
    }
}
