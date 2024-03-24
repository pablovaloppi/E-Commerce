using E_Commerce.ServiceExtensions;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureDbContext( builder.Configuration );

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
