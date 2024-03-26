using E_Commerce.CustomExceptionMiddleware;
using E_Commerce.Responses;
using Entities.Model;
using Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
using System.Net;

namespace E_Commerce.ServiceExtensions
{
    public static class ServiceExtension
    {
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
        public static void ConfigureCustomExceptionMiddleware( this WebApplication app ) {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void ConfigureServicesEntities( this IServiceCollection services ) {
            services.AddScoped<CategoryService>();
        }
    }
}
