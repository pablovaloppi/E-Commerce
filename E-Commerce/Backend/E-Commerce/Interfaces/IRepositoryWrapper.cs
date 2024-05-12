using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }
        ICommentRepository Comment { get; }
        IImageRepository Image { get; }
        IProductRepository Product { get; }
        IProductSaleRepository ProductSale { get; }
        ISaleRepository Sale { get; }
        ISellerRepository Seller { get; }
        IUserRepository User { get; }
        IUserTypeRepository UserType { get; }
        IShoppingCartRepository ShoppingCart { get; }
        ICartItemRepository CartItem { get; }
        Task SaveAsync();
        Task SetTransaction();
        Task CommitTransaction();
    }
}
