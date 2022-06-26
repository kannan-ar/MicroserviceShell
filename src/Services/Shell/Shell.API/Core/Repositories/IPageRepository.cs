using Shell.API.Models.Entities;
using System.Threading.Tasks;

namespace Shell.API.Core.Repositories
{
    public interface IPageRepository : IDbRepository<PageMetaData>
    {
        Task<PageMetaData> GetPage(string pageName);
    }
}
