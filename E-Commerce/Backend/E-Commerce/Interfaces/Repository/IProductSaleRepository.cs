using Entities.Helpers;
using Entities.Model;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IProductSaleRepository
    {
        Task<IEnumerable<ProductSale>> GetAllAsync();
        //Task<IEnumerable<ProductSale>> GetAllByUserId( int userId );
        Task<ProductSale> GetBySaleIdAsync( int id );
        void CreateProductSale( ProductSale productSale );
        void CreateProductSaleRange( IEnumerable<ProductSale> productSales );
        void DeleteProductSale( ProductSale productSale );
    }
}
