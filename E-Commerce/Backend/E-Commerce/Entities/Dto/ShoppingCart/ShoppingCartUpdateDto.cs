using Entities.Dto.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.ShoppingCart
{
    public class ShoppingCartUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public float Total { get; set; }
        public IEnumerable<CartItemUpdateDto> CartItems { get; set; }
    }
}
