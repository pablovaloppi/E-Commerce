using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public float Total { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }

    }
}
