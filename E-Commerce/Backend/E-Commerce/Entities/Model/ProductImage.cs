using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class ProductImage {
        public int ProductId { get; set; }
        public int ImageId { get; set; }

        public Product Product { get; set; }
        public Image Image { get; set; }
    }
}
