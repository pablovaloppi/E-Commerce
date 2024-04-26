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
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure( EntityTypeBuilder<CartItem> builder ) {
            builder.ToTable( "cart_item" );
            
            builder.HasKey( cart => cart.Id );

            builder.Property( cart => cart.Quantity )
                .HasColumnName( "quantity" )
                .HasColumnType( "int" );

            builder.Property( cart => cart.TotalPrice )
               .HasColumnName( "total_price" )
               .HasColumnType( "smallmoney" );

            builder.HasOne( cart => cart.Product )
                .WithMany( product => product.CartItems )
                .HasForeignKey( cart => cart.ProductId );

            builder.HasOne( cart => cart.ShoppingCart )
                 .WithMany( shopCart => shopCart.CartItems )
                 .HasForeignKey( cart => cart.ShoppingCartId );
        }
    }
}
