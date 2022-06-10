using Common.Logging;
using Identity.API.Data;
using Identity.API.Extensions;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Identity.API
{
    public class Program
    {
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            var host = CreateHostBuilder(configuration, args).Build();

            host.MigrateDbContext<PersistedGrantDbContext>((_, __) => { })
            .MigrateDbContext<ApplicationDbContext>((_, __) => { })
            .MigrateDbContext<ConfigurationDbContext>((context, services) =>
            {
                new ConfigurationDbContextSeed().SeedAsync(context).Wait();
            });

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.CaptureStartupErrors(false);
                    webBuilder.ConfigureAppConfiguration(x => x.AddConfiguration(configuration));
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.ConfigureSerilog();
                });
    }
}
