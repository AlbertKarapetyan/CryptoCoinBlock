using CM.Application.DIConfiguration;
using CM.Application.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
var loggerFactory = LoggerFactory.Create(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

// Add services to the container.
builder.Services.AddServices(loggerFactory.CreateLogger("DIServicesRegistration"));
builder.Services.AddAutoMappers(loggerFactory.CreateLogger("AutoMappersRegistration"));

builder.Services.AddMediatr(loggerFactory.CreateLogger("MediatRConfiguration"));

builder.Services.AddHttpClient();

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(builder.Configuration, loggerFactory.CreateLogger("DbContextConfiguration"));

// Define CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("BasicCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()  // Allow all origins
              .AllowAnyHeader()   // Allow all headers
              .WithMethods("GET", "POST") // Allow only GET and POST methods
              .AllowCredentials();
    });
});

var app = builder.Build();

Console.WriteLine("Starting...");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RateLimitingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

// Add the health check endpoint
app.MapHealthChecks("/health");

app.MapControllers();

app.Run();
