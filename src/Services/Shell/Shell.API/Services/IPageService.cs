using Shell.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shell.API.Services
{
    public interface IPageService
    {
        Task AddPage(PageMetaData metaData);
        Task<IEnumerable<PageMetaData>> GetAllAsync();
    }
}
