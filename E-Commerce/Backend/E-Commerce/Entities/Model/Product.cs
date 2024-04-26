﻿using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Product : ICustomEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float Price { get; set; }
        public int Amount { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<ProductSale> ProductsSales { get; set; }
    }
}
