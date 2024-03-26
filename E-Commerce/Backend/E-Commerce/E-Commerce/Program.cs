using E_Commerce.ServiceExtensions;
using Interfaces;
using NLog;

var builder = WebApplication.CreateBuilder( args );

// Set Path to save logs files
LogManager.Setup().LoadConfigurationFromFile( string.Concat( Directory.GetCurrentDirectory(), "/nlog.config" ) );

// Add services to the container.

builder.Services.AddControllers();

// Configure DbContext
builder.Services.ConfigureDbContext( builder.Configuration );

// Set LoggerServices
builder.Services.ConfigureLoggerService();

// I.D repositoryWrapper
builder.Services.ConfigureRepositoryWrapper();

//I.D services entities
builder.Services.ConfigureServicesEntities();

var app = builder.Build();

// Configure ExceptionMiddleware
app.ConfigureCustomExceptionMiddleware();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
