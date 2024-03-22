using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure( EntityTypeBuilder<Product> builder ) {

            builder.ToTable( "product" );
            builder.HasKey( p => p.Id );

            builder.Property( p => p.Id ).HasColumnName( "id" );

            builder.Property( p => p.Name ).HasColumnName( "name" ).HasMaxLength( 120 ).IsUnicode( false );

            builder.HasOne<Categoria>( p => p.Categoria )
                .WithMany( d => d.Products )
                .HasForeignKey( e => e.Id )
                .IsRequired( false );
        }
    }
}
