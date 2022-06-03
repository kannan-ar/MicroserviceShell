namespace MicroFrontend.API.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddIdentityAuthentication(builder.Configuration);
            builder.Services.AddSwagger(builder.Configuration);
            builder.Services.AddEntityMapper();
            builder.Services.AddMongoDb(builder.Configuration);
            builder.Services.AddServices();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(setup =>
                {
                    setup.OAuthClientId("mfswaggerui");
                    setup.OAuthAppName("Swagger UI for Microfrontend");
                });
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
