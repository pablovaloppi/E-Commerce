using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IShoppingCartRepository {
        Task<ShoppingCart> GetShoppingCartByUserAsync( int id );
        Task<ShoppingCart> GetShoppingCartByIdAsync( int id );
        void CreateShoppingCart(ShoppingCart cart);
        void UpdateShopCart( ShoppingCart shoppingCart );
    }
}
