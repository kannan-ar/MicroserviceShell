using Identity.API;
using Identity.API.Data;
using Identity.API.Extensions;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore;

var configuration = GetConfiguration();

try
{
    var host = BuildWebHost(configuration, args);

    host.MigrateDbContext<PersistedGrantDbContext>((_, __) => { })
        .MigrateDbContext<ApplicationDbContext>((_, __) => { })
        .MigrateDbContext<ConfigurationDbContext>((context, services) =>
        {
            new ConfigurationDbContextSeed().SeedAsync(context).Wait();
        });

    host.Run();
    return 0;
}
catch
{
    return 1;
}

IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
    WebHost.CreateDefaultBuilder(args)
    .CaptureStartupErrors(false)
    .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
    .UseStartup<Startup>()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .Build();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}