using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shell.API.Application.Validators;
using Shell.API.Extensions;
using Shell.API.Middlewares;

namespace Shell.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddMongoDb(Configuration);
            services.AddRepositories();
            services.AddAuthorization(options => options.AddAuthorizationPolicies());

            services.AddIdentityAuthentication(Configuration);
            services.AddSwagger(Configuration);
            services.AddEntityMapper();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddServices();
            services.AddValidatorsFromAssemblyContaining<ComponentValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(setup =>
                {
                    setup.SwaggerEndpoint("/swagger/v1/swagger.json", "ShellUI.API v1");
                    setup.OAuthClientId("mfswaggerui");
                    setup.OAuthAppName("Swagger UI for Microfrontend");
                });
            }
            else
            {
                app.UseMiddleware<ExceptionMiddleware>();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
