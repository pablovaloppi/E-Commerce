using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public  interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> getAllByShopCartIdAsync( int userId);
        Task<CartItem> GetCartItemByIdAsync( int cartItemId );
        void CreateItem( CartItem cartItem );
        void DeleteCartItem( CartItem cartItem );
    }
}
