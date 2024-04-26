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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure( EntityTypeBuilder<Product> builder ) {
            builder.ToTable( "product" );

            builder.HasKey( product => product.Id );

            builder.HasIndex( product => product.Title, "UQ_product" )
                .IsUnique();

            builder.Property( product => product.Title )
                .IsRequired()
                .HasColumnName( "title" )
                .HasColumnType( "nvarchar" )
                .HasMaxLength( 60 );

            builder.Property( product => product.Description )
                .HasColumnName( "description" )
                .HasColumnType( "text" );

            builder.Property( product => product.Price )
                .HasColumnName( "price" )
                .HasColumnType( "decimal(12,2)" );

            builder.Property(product => product.Amount )
                .HasColumnName( "amount" )
                .HasColumnType( "int" );

            builder.HasOne( product => product.Category )
                .WithMany( category => category.Products )
                .HasForeignKey( product => product.CategoryId );



        }
    }
}
