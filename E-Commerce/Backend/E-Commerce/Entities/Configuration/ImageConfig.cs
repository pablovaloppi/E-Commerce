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
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure( EntityTypeBuilder<Image> builder ) {
            builder.ToTable( "image" );

            builder.HasKey( image => image.Id );

            builder.Property( image => image.Name )
                .HasColumnName( "name" )
                .HasColumnType( "nvarchar" );
        }
    }
}
