using Entities.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.Products
{
    public class ProductCreateDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float Price { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
