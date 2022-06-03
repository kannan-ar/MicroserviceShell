using MicroFrontend.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();

//builder.Services.AddControllers();

//builder.Services.AddIdentityAuthentication(builder.Configuration);
//builder.Services.AddSwagger(builder.Configuration);
//builder.Services.AddMongoDb(builder.Configuration);

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(setup =>
//    {
//        setup.OAuthClientId("mfswaggerui");
//        setup.OAuthAppName("Swagger UI for Microfrontend");
//    });
//}

//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapDefaultControllerRoute();
//    endpoints.MapControllers();
//});


