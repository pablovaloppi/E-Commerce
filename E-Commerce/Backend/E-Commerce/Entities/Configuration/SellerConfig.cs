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
    public class SellerConfig : IEntityTypeConfiguration<Seller>
    {
        public void Configure( EntityTypeBuilder<Seller> builder ) {
            builder.ToTable( "seller" );

            builder.HasKey( seller => seller.Id );

            builder.Property( seller => seller.SaleQuantity )
                .HasColumnName( "sale_quantity" )
                .HasColumnType( "int" );
        }
    }
}
