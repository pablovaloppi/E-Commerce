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
    public class ProductSaleConfig : IEntityTypeConfiguration<ProductSale>
    {
        public void Configure( EntityTypeBuilder<ProductSale> builder ) {
            builder.HasKey( productSale => new { productSale.SaleId, productSale.ProductId } );

            builder.Property( productSale => productSale.ProductQuantity )
                .HasColumnName( "product_quantity" )
                .HasColumnType( "int" );

            builder.HasOne( productSale => productSale.Sale )
                .WithMany( sale => sale.ProductsSales )
                .HasForeignKey( productSale => productSale.SaleId );

            builder.HasOne( productSale => productSale.Product )
                .WithMany( product => product.ProductsSales )
                .HasForeignKey( productSale => productSale.ProductId );
        }
    }
}
