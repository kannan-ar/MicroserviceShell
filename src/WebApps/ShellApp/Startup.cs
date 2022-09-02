using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShellApp.Core.Services;
using ShellApp.Extensions;
using ShellApp.Route;

namespace ShellApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddCustomAuthentication(Configuration);
            services.AddServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IPageService pageService)
        {
            app.UseExceptionHandler("/Shell/Error");

            app.UseStaticFiles();
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "pages",
                    pattern: string.Format("pages/{{{0}}}", RouteConstants.Page),
                    defaults: new { controller = "Shell", action = "Index" },
                    constraints: new { page = new SiteRouteConstraint(pageService) });

                endpoints.MapControllerRoute("default", "{controller=Shell}/{action=Index}/{id?}");
                endpoints.MapControllers();

            });
        }
    }
}
