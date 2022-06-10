using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Data
{
    public interface IDbRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task Add(T entity);
    }
}
