using Shell.API.Models.Entities;
using System.Threading.Tasks;

namespace Shell.API.Core.Repositories
{
    public interface IPageRepository : IDbRepository<PageMetaData>
    {
        Task<PageMetaData> GetPage(string pageName);
        Task InsertOrUpdatePageAsync(string pageName, PageMetaData page);
        Task<PageMetaData> UpdatePageAsync(string pageName, PageMetaData page);
        Task DeletePageAsync(string pageName);
    }
}
