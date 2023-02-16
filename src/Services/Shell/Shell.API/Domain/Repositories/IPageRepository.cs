using Shell.API.Models.Entities;
using System.Threading.Tasks;

namespace Shell.API.Domain.Repositories
{
    public interface IPageRepository : IDbRepository<PageMetaData>
    {
        Task<PageMetaData> GetPageAsync(string pageName);
        Task<PageMetaData> InsertOrUpdatePageAsync(string pageName, PageMetaData page);
        Task<PageMetaData> UpdatePageAsync(string pageName, PageMetaData page);
        Task DeletePageAsync(string pageName);
    }
}
