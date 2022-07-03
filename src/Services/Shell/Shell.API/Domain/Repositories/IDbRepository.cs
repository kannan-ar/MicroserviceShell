using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Domain.Repositories
{
    public interface IDbRepository<T>
    {
        Task InsertAsync(T entity);
        Task<IEnumerable<T>> GetAsync();
    }
}
