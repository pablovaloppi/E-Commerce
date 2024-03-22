using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<ProductImage> PruductsImages { get; set; }
    }
}
