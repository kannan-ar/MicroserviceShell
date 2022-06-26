using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShellApp.Core.Services;

namespace ShellApp.Route
{
    public class SiteRouteConstraint : IRouteConstraint
    {
        private readonly IPageService _pageService;

        public SiteRouteConstraint(IPageService pageService)
        {
            _pageService = pageService;
        }

        public bool Match(
            HttpContext httpContext,
            IRouter route, 
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var pageName = values[routeKey]?.ToString();

            if (string.IsNullOrEmpty(pageName)) return true;

            httpContext.Items[RouteConstants.Page] = pageName;

            return _pageService.IsPageExists(pageName).Result;
        }
    }
}
