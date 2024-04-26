using Entities.Helpers;
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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ECommerceDbContext _eCommerceDbContext;
        public ProductRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
            _eCommerceDbContext = eCommerceDbContext;
        }

        public void CreateProduct( Product product ) {
            Create( product );
        }
        public Task<Product> GetByTitle( string title ) {
            return FindByCondition( product => product.Title == title ).FirstOrDefaultAsync();
        }

        public void DeleteProduct( Product product ) {
            Delete( product );
        }

        public async Task<PagedList<Product>> GetAllAsync( ProductParameters parameters ) {

            var result = _eCommerceDbContext.Products
                    .Include( product => product.Images )
                    .Include(product => product.Category);

            return await PagedList<Product>.ToPagedListAsync( result, parameters.PageNumber, parameters.PageSize );
        }

        public async Task<Product> GetByIdAsync( int id ) {
            var result = await _eCommerceDbContext.Products.
                Include( product => product.Images ).
                Where( product => product.Id == id ).FirstOrDefaultAsync();
            return result;
        }

        public void UpdateProduct( Product product ) {
            Update( product );
        }
    }
}
