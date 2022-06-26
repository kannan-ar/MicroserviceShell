using Refit;
using System.Threading.Tasks;

namespace ShellApp.API
{
    public interface IPageApi
    {
        [Get("/api/page/IsExists/{pageName}")]
        Task<bool> IsPageExists([AliasAs("pageName")] string pageName);
    }
}
