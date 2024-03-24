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
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure( EntityTypeBuilder<Sale> builder ) {
            builder.ToTable( "sale" );

            builder.HasKey( sale => sale.Id );

            builder.HasOne( sale => sale.User )
                .WithMany( user => user.Sales )
                .HasForeignKey( sale => sale.UserId );

            builder.HasOne( sale => sale.Seller )
                .WithMany( seller => seller.Sales )
                .HasForeignKey( sale => sale.SellerId );
        }
    }
}
