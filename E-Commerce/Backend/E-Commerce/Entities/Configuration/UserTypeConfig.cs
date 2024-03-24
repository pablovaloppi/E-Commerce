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
    public class UserTypeConfig : IEntityTypeConfiguration<UserType>
    {
        public void Configure( EntityTypeBuilder<UserType> builder ) {
            builder.ToTable( "userType" );

            builder.HasKey( usertype => usertype.Id );

            builder.HasIndex( usertype => usertype.Type, "UQ_usertype" )
                .IsUnique();

            builder.Property( usertype => usertype.Type )
                .HasColumnName( "type" )
                .HasColumnType( "nvarchar" )
                .HasMaxLength( 15 );
        }
    }
}
