using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace ShellApp.Extensions
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder ConfigureSerilog(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSerilog((context, configuration) =>
            {
                configuration
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Console()
                    .WriteTo.Elasticsearch(
                        new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                        {
                            IndexFormat = $"applogs-{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{context.HostingEnvironment.EnvironmentName?.Replace(".", "-")}-logs-{DateTime.UtcNow:yyyy-MM}",
                            AutoRegisterTemplate = true,
                            NumberOfShards = Convert.ToInt32(context.Configuration["ElasticConfiguration:NumberOfShards"]),
                            NumberOfReplicas = Convert.ToInt32(context.Configuration["ElasticConfiguration:NumberOfReplicas"])
                        })
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .ReadFrom.Configuration(context.Configuration);
            });

            return webHostBuilder;
        }
    }
}
