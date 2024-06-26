﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Sale
    {
        public int Id { get; set; }

        public float TotalAmount { get; set; }

        public DateTime SaleDate { get; set; }
        public int UserId { get; set; }
        //public int SellerId { get; set; }

        public User User { get; set; }
        //public Seller Seller { get; set; }

        public IEnumerable<ProductSale> ProductsSales { get; set; }

    }
}
