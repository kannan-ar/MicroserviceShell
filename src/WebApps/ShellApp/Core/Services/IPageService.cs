using System.Threading.Tasks;

namespace ShellApp.Core.Services
{
    public interface IPageService
    {
        Task<bool> IsPageExists(string pageName);
    }
}
