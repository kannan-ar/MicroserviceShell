using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Core.Services
{
    public interface IPageService
    {
        Task InsertPage(PageMetaData metaData);
        Task<IEnumerable<PageMetaData>> GetPagesAsync();
        Task<PageMetaData> GetPageAsync(string pageName);
        Task<bool> IsPageExists(string pageName);
        Task UpsertPage(string pageName, PageMetaData metaData);
        Task<PageMetaData> UpdatePage(string pageName, PageMetaData metaData);
        Task DeletePage(string pageName);
    }
}
