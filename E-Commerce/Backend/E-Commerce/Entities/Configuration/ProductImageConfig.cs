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
    public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure( EntityTypeBuilder<ProductImage> builder ) {

            builder.ToTable( "product_image" );

            builder.HasKey( productImage => new { productImage.ProductId, productImage.ImageId } );

            builder.HasOne( productImage => productImage.Product )
                .WithMany( product => product.PruductsImages )
                .HasForeignKey( productImage => productImage.ProductId );

            builder.HasOne( productImage => productImage.Image )
                .WithMany( image => image.PruductsImages )
                .HasForeignKey( productImage => productImage.ImageId );
        }
    }
}
