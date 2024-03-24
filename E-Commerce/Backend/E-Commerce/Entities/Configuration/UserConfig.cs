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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder ) {
            builder.ToTable( "user" );

            builder.HasKey( user => user.Id );

            builder.HasIndex( user => user.UserName, "UQ_user_username" )
                .IsUnique();

            builder.Property( user => user.UserName )
                .HasColumnName( "username" )
                .HasColumnType( "nvarchar" )
                .HasMaxLength( 20 );

            builder.Property( user => user.Password )
                .HasColumnName( "password" )
                .HasColumnType( "nvarchar" )
                .HasMaxLength( 30 );

            builder.Property( user => user.Address )
                            .HasColumnName( "addres" )
                            .HasColumnType( "nvarchar" )
                            .HasMaxLength( 50 );

            builder.HasIndex( user => user.Email, "UQ_user_email" )
                .IsUnique();

            builder.Property( user => user.Email )
                .HasColumnName( "email" )
                .HasColumnType( "nvarchar" )
                .HasMaxLength( 30 );

            builder.Property( user => user.DateOfBirth )
                .HasColumnName( "date_of_birth" )
                .HasColumnType( "date" );

            builder.Property( user => user.DateOfCreation )
                .HasColumnName( "date_of_creation" )
                .HasColumnType( "date" );

            builder.Property( user => user.PurchaseCount )
                .HasColumnName( "purchase_count" )
                .HasColumnType( "int" );

            builder.HasOne( user => user.UserType )
                .WithMany( usertype => usertype.Users )
                .HasForeignKey( user => user.UserTypeId );

            builder.HasOne( user => user.Seller )
                .WithMany( seller => seller.Users )
                .HasForeignKey( user => user.SellerId );

        }
    }
}
