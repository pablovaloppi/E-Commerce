using Proyecto_Signal;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddCors( options => {
    options.AddPolicy( "CorsPolicy", builder => builder
            .WithOrigins( "http://localhost:4200" )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials() );
} );

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapHub<ChatHub>( "/hubs/chat" );

app.UseCors( "CorsPolicy" );

app.UseAuthorization();

app.MapControllers();


app.Run();
