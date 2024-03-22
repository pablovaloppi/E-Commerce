using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models.Configuration
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure( EntityTypeBuilder<Categoria> builder ) {
            builder.ToTable( "categoria" );

            builder.HasKey( x => x.Id );
            builder.Property( e => e.Id ).HasColumnName( "id" );
            builder.Property( c => c.Name ).HasColumnName( "name" ).HasMaxLength( 150 ).IsUnicode( false );

            
        }
    }
}
