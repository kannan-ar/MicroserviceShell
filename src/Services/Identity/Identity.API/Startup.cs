using Identity.API.Data;
using Identity.API.Extensions;
using Identity.API.Mapping;
using Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace Identity.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }


        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionString"];
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddAppInsights(Configuration);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(migrationsAssembly);
                    EnableRetryOnFailure(sqlOptions);
                }));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDataProtectionBasedOnConfiguration(Configuration);

            services.AddAutoMapper(typeof(ClientProfile));
            services.RegisterRepositories();
            services.RegisterServices();


            services.AddIdentityServer(x =>
            {
                x.IssuerUri = "null";// Configuration.GetValue<string>("IssuerUri");
                x.Authentication.CookieLifetime = TimeSpan.FromMinutes(30);
            })
             .AddSigningCredentialBasedOnEnviornment(_env)
             .AddAspNetIdentity<ApplicationUser>()
             .AddConfigurationStore(options =>
             {
                 options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString,
                     sqlServerOptionsAction: sqlOptions =>
                     {
                         sqlOptions.MigrationsAssembly(migrationsAssembly);
                         EnableRetryOnFailure(sqlOptions);
                     });
             })
             .AddOperationalStore(options =>
             {
                 options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString,
                     sqlServerOptionsAction: sqlOptions =>
                     {
                         sqlOptions.MigrationsAssembly(migrationsAssembly);
                         EnableRetryOnFailure(sqlOptions);
                     });
             });

            services.AddSwagger();

            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shell v1"));
            }

            app.UseStaticFiles();

            app.UseForwardedHeaders();
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
            app.UseIdentityServer();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }

        private static void EnableRetryOnFailure(SqlServerDbContextOptionsBuilder sqlOptions)
        {
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        }
    }
}
