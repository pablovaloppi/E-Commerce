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
    public class ShoppingCartRepository : RepositoryBase<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
        }

        public void CreateShoppingCart( ShoppingCart cart ) {
            Create( cart );
        }

        public async Task<ShoppingCart> GetShoppingCartByIdAsync( int id ) {
            return await FindByCondition( cart => cart.Id == id )
                .Include( cart => cart.CartItems )
                .ThenInclude(cartItem => cartItem.Product)
                .ThenInclude(product => product.Images).FirstOrDefaultAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByUserAsync( int id ) {
            return await FindByCondition( cart => cart.UserId == id ).AsNoTracking().Include( cart => cart.CartItems).FirstOrDefaultAsync(); //.Include( cart => cart.CartItems )
        }

        public void UpdateShopCart( ShoppingCart shoppingCart ) {
            Update( shoppingCart );
            
        }
    }
}
