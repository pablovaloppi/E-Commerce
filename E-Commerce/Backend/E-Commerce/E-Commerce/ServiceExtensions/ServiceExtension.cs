using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext( this IServiceCollection services, IConfiguration configuration ) {
            
            services.AddDbContext<ECommerceDbContext>( options => {
                options.UseSqlServer( configuration.GetConnectionString( "E-CommerceConection" ) );
            } );
        }
    }
}
