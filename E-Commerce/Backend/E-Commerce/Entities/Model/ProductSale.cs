﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class ProductSale
    {
        public int ProductQuantity { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }

        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}
