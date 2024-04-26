using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class ShoppingCartConfig : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure( EntityTypeBuilder<ShoppingCart> builder ) {
            builder.ToTable("shopping_cart" );

            builder.HasKey( cart => cart.Id );

            builder.Property( cart => cart.Total )
                .HasColumnName( "total" )
                .HasColumnType( "smallmoney" );

 
        }
    }
}
