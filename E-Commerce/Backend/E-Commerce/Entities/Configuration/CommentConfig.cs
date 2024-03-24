using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure( EntityTypeBuilder<Comment> builder ) {

            builder.ToTable( "comment" );

            builder.HasKey( comment => comment.Id );

            builder.Property( comment => comment.Content )
                .IsRequired()
                .HasMaxLength( 255 )
                .HasColumnName( "content" )
                .HasColumnType( "nvarchar" );

            builder.Property( comment => comment.Date )
                .HasColumnType( "date" );

            builder.HasOne( comment => comment.User )
                .WithMany( user => user.Comments )
                .HasForeignKey( comment => comment.UserId );

            builder.HasOne( comment => comment.Product )
                .WithMany( product => product.Comments )
                .HasForeignKey( comment => comment.ProductId );

            builder.HasOne( comment => comment.Response )
                .WithMany()
                .HasForeignKey( comment => comment.CommentId )
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
