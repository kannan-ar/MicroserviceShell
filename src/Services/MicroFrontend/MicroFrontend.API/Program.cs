using MicroFrontend.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddIdentityAuthentication(builder.Configuration);
builder.Services.AddSwagger(builder.Configuration);

var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.OAuthClientId("mfswaggerui8");
        setup.OAuthAppName("M Swagger UI8");
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

app.Run();
