using ShellApp.Models;
using System.Threading.Tasks;

namespace ShellApp.Core.Services
{
    public interface IPageService
    {
        Task<bool> IsPageExists(string pageName);
        Task<PageModel> Get(string pageName);
    }
}
