using E_Commerce.ServiceExtensions;
using Interfaces;
using Microsoft.Extensions.FileProviders;
using NLog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder( args );

// Set Path to save logs files
LogManager.Setup().LoadConfigurationFromFile( string.Concat( Directory.GetCurrentDirectory(), "/nlog.config" ) );

//Configure Cors
builder.Services.ConfigureCors();

// Add services to the container.

                                    // Esto resuelve errode de ciclo longitud > 32
builder.Services.AddControllers();//.AddJsonOptions( x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);



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

// Esto me permite acceder a archivos estaticos con una solicitud http
// TODO: hacer que las carpetas Resource se relacionen a la constantes de upload services( Hacer leibles el nombre desde un arhivo de configuracion)
app.UseStaticFiles( new StaticFileOptions() {
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources" )),
    RequestPath = new PathString("/Resources")
} );


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
