using E_Commerce.CustomExceptionMiddleware;
using E_Commerce.Responses;
using Entities.Helpers;
using Entities.Model;
using Entities.Validators;
using Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Services;
using System.Net;
using System.Text;
using Validators;

namespace E_Commerce.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services ) {
            services.AddCors( options => {
                options.AddPolicy( "CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders( "X-Pagination" )
                    );
            } );
        }
        public static void ConfigureDbContext( this IServiceCollection services, IConfiguration configuration ) {
            
            services.AddDbContext<ECommerceDbContext>( options => {
                options.UseSqlServer( configuration.GetConnectionString( "E-CommerceConection" ) );
            } );
        }
        public static void ConfigureLoggerService(this IServiceCollection services ) {
            services.AddSingleton<ILoggerManager, LoggerService>();
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services ) {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }    

        public static void ConfigureCustomValidator(this IServiceCollection services ) {
            // Cuando se requiere una Instancia del typeof ICustomValidator<>
            // Le devuelvo una instancia del typeof CustomValidator<>
            services.AddScoped( typeof( ICustomValidator<> ), typeof( CustomValidator<> ) );
        }

        public static void ConfigureCustomExceptionMiddleware( this WebApplication app ) {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void ConfigureServicesEntities( this IServiceCollection services ) {
 
            services.AddScoped<CategoryService>();
            services.AddScoped<AuthService>();
            services.AddScoped<ProductService>();
            services.AddScoped<FileUploadService>();
            services.AddScoped<ImageService>();
            services.AddScoped<CartItemService>();
            services.AddScoped<ShoppingCartService>();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration ) {
            services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme ).AddJwtBearer( options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    // Solo permite tokens generados por la dir http del Issuer (dir servidor)
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection( "Jwt:Issuer" ).Value,
                    //---
                    // Solo admite tokens generados por la dir http de la Audience( dir web)
                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection( "Jwt:Audience" ).Value,
                    //---
                    ValidateLifetime = true,
                    // Verifica que la signature de jwt sea la correcta que se genero con la key
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( configuration.GetSection( "Jwt:Key" ).Value! ) )
                    //---
                };
            } );
        }

    }
}
