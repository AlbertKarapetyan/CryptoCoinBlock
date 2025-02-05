using CM.ApiGateway.Logging;
using CM.ApiGateway.Middleware;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var environment = builder.Environment.EnvironmentName;

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"ocelot.{environment}.json", optional: true, reloadOnChange: true);

builder.Services.AddOcelot();

// Load configuration with auto-reload enabled
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Configure Serilog for ELK logging using custom configuration class
LoggingConfiguration.ConfigureSerilog(builder);

builder.Services.AddLogging();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<CoinValidationMiddleware>();

app.UseOcelot().Wait();

app.Run();
