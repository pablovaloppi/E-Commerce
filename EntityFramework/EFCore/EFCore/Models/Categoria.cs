﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; }
    }
}
