using MarmindSample.Infrastructure;
using MarmindSample.Infrastructure.Data;
using MarmindSample.Web;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(hostContext.Configuration)
        .Enrich.FromLogContext();
});


// Enforce lowercase URLs globally
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

// Add services to the container.
builder.AddKeyVaultIfConfigured();
builder.AddApplicationServices();
builder.AddInfrastructureServices();
builder.AddWebServices();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.UseHealthChecks("/health");
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});


app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();

public partial class Program { }
