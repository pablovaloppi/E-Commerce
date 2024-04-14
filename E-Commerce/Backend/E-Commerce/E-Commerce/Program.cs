using E_Commerce.ServiceExtensions;
using Interfaces;
using NLog;

var builder = WebApplication.CreateBuilder( args );

// Set Path to save logs files
LogManager.Setup().LoadConfigurationFromFile( string.Concat( Directory.GetCurrentDirectory(), "/nlog.config" ) );

//Configure Cors
builder.Services.ConfigureCors();

// Add services to the container.

builder.Services.AddControllers();



// Configure DbContext
builder.Services.ConfigureDbContext( builder.Configuration );

// Set LoggerServices
builder.Services.ConfigureLoggerService();

// I.D repositoryWrapper
builder.Services.ConfigureRepositoryWrapper();

// I.D custom validators
builder.Services.ConfigureCustomValidator();

//I.D services entities
builder.Services.ConfigureServicesEntities();

//Add Automapper
builder.Services.AddAutoMapper( typeof( Program ) );

//ConfigureJWT
builder.Services.ConfigureJWT( builder.Configuration );


var app = builder.Build();

// Configure ExceptionMiddleware
app.ConfigureCustomExceptionMiddleware();
// Configure the HTTP request pipeline.


app.UseCors( "CorsPolicy" );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
