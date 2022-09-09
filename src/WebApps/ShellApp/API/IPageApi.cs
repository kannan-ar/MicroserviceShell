using Refit;
using ShellApp.Models;
using System.Threading.Tasks;

namespace ShellApp.API
{
    public interface IPageApi
    {
        [Get("/api/page/IsExists/{pageName}")]
        Task<bool> IsPageExists([AliasAs("pageName")] string pageName);

        [Get("/api/page/{pageName}")]
        Task<PageModel> Get([AliasAs("pageName")] string pageName);
    }
}
