using Microsoft.AspNetCore;
using ShellApp;

var configuration = GetConfiguration();

try
{
    var host = BuildWebHost(configuration, args);
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