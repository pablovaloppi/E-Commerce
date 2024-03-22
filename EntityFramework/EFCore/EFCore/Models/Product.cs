﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public Categoria Categoria { get;set; } = null!;
    }
}
