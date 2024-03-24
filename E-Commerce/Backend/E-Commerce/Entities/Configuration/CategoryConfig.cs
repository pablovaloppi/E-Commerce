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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure( EntityTypeBuilder<Category> builder ) {
            builder.ToTable( "category" );

            builder.HasKey( category => category.Id );

            builder.HasIndex( category => category.Name, "UQ_category" )
                .IsUnique();

            builder.Property( category => category.Name )
                .IsRequired()
                .HasColumnName( "nvarchar" )
                .HasMaxLength( 20 );

        }
    }
}
