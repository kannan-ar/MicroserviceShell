using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Core.Repositories
{
    public interface IDbRepository<T>
    {
        Task InsertAsync(T entity);
        Task<IEnumerable<T>> GetAsync();
    }
}
