using Entities.Model;
using Entities.Parameters;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductSaleRepository : RepositoryBase<ProductSale>, IProductSaleRepository
    {
        private readonly ECommerceDbContext _eCommerceDbContext;

        public ProductSaleRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
            _eCommerceDbContext = eCommerceDbContext;
        }

        public void CreateProductSale( ProductSale productSale ) {
            Create( productSale );
        }

        public void CreateProductSaleRange( IEnumerable<ProductSale> productSales ) {
            CreateRange( productSales );
        }

        public void DeleteProductSale( ProductSale productSale ) {
            Delete( productSale );
        }

        public Task<IEnumerable<ProductSale>> GetAllAsync() {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<ProductSale>> GetAllByUserId( int userId ) {
        //    var result = _eCommerceDbContext.Sales.Where( sale => sale.UserId == userId )
        //        .Include( productSale => productSale.ProductsSales )
        //        .Select( productSales => productSales.ProductsSales );

        //    return result;
        //}

        public Task<ProductSale> GetBySaleIdAsync( int id ) {
            return FindByCondition(productSale => productSale.SaleId == id).FirstOrDefaultAsync();
        }
    }
}
