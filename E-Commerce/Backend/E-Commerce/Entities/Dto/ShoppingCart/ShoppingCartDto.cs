using Entities.Dto.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.ShoppingCart
{
    public class ShoppingCartDto
    {
        public float Total { get; set; }
        public IEnumerable<CartItemDto> CartItems { get; set; }
    }
}
