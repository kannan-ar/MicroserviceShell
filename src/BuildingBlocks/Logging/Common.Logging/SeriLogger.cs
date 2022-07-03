using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;

namespace Common.Logging
{
    public static class SeriLogger
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
                            IndexFormat = $"applogs-{context.Configuration["ElasticConfiguration:LogPrefix"]}-{context.HostingEnvironment.EnvironmentName?.Replace(".", "-")}-logs-{DateTime.UtcNow:yyyy-MM}",
                            AutoRegisterTemplate = true,
                            NumberOfShards = 1,
                            NumberOfReplicas = 2
                        })
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .ReadFrom.Configuration(context.Configuration);
            });

            return webHostBuilder;
        }
    }
}
