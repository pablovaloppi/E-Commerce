using Entities.Model;
using Interfaces;
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
        public ProductRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
        }

        public void CreateProduct( Product product ) {
            Create( product );
        }

        public void DeleteProduct( Product product ) {
            Delete( product );
        }

        public async Task<IEnumerable<Product>> GetAllAsync() {
            return await Get().ToListAsync();
        }

        public async Task<Product> GetByIdAsync( int id ) {
            return await FindByCondition( product => product.Id == id ).FirstOrDefaultAsync();
        }

        public void UpdateProduct( Product product ) {
            Update( product );
        }
    }
}
