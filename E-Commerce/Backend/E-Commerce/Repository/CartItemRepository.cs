using Entities.Model;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
    {
        private readonly ECommerceDbContext _eCommerceDbContext;

        public CartItemRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
            _eCommerceDbContext = eCommerceDbContext;
        }
        public async Task<IEnumerable<CartItem>> getAllByShopCartIdAsync( int shopCartId ) {
            return await FindByCondition( cartItem => cartItem.ShoppingCartId == shopCartId).Include( cartItem => cartItem.Product).ToListAsync();
        }

        public void CreateItem( CartItem cartItem ) {
            Create(cartItem);
        }
        public void UpdateItem(CartItem cartItem ) {
            Update( cartItem );
        }
        public void DeleteCartItem( CartItem cartItem ) {
            Delete( cartItem );
        }

        public void DeleteCartItemRange( IEnumerable<CartItem> cartItems ) {
            DeleteRange( cartItems );
        }

        public async Task<CartItem> GetCartItemByIdAsync( int cartItemId ) {
            return await FindByCondition( cart => cart.Id == cartItemId ).Include( cartItem => cartItem.Product ).FirstOrDefaultAsync();
        }

        public void UpdateItemRange( IEnumerable<CartItem> cartItems ) {
            _eCommerceDbContext.UpdateRange( cartItems );
        }
    }
}
