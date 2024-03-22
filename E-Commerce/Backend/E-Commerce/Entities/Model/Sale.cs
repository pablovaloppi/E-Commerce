using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Sale
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int SellerId { get; set; }

        public IEnumerable<ProductSale> ProductsSales { get; set; }

    }
}
