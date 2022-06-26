using ShellApp.API;
using ShellApp.Core.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShellApp.Services
{
    public class PageService : IPageService
    {
        private readonly IPageApi _pageApi;

        public PageService(IPageApi pageApi)
        {
            _pageApi = pageApi;
        }

        public async Task<bool> IsPageExists(string pageName)
        {
            return await _pageApi.IsPageExists(pageName);
        }
    }
}
