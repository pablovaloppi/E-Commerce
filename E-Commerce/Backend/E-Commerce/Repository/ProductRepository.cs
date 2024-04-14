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

        public void DeleteProduct( Product product ) {
            Delete( product );
        }

        public async Task<PagedList<Product>> GetAllAsync( ProductParameters parameters ) {
            //SELECT p.id, p.title, p.price,  p.amount, c.Id, c.nvarchar FROM product p join category c on p.CategoryId = c.Id;
            var result = from products in _eCommerceDbContext.Products
                         join category in _eCommerceDbContext.Categories
                         on products.CategoryId equals category.Id
                         select new Product() {
                                Id = products.Id, Title = products.Title, Description = products.Description,
                                Price = products.Price, Amount = products.Amount, CategoryId = products.CategoryId, Category = category
                         } ;

            return await PagedList<Product>.ToPagedListAsync( result, parameters.PageNumber, parameters.PageSize );
        }

        public async Task<Product> GetByIdAsync( int id ) {
            var result = await (from products in _eCommerceDbContext.Products
                         join category in _eCommerceDbContext.Categories
                         on products.CategoryId equals category.Id
                         where products.Id == id
                         select new Product() {
                             Id = products.Id, Title = products.Title, Description = products.Description,
                             Price = products.Price, Amount = products.Amount, CategoryId = products.CategoryId, Category = category
                         }).FirstOrDefaultAsync();
            return result;
        }

        public void UpdateProduct( Product product ) {
            Update( product );
        }
    }
}
