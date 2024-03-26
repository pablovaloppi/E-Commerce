using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
        }

        public void CreateCategory( Category category ) {
            Create( category );
        }

        public void DeleteCategory( Category category ) {
            Delete( category );
        }

        public async Task<IEnumerable<Category>> GetAllAsync() {
            return await Get().ToListAsync();
        }

        public async Task<Category> GetByIdAsync( int id ) {
            return await FindByCondition( category => category.Id == id ).FirstOrDefaultAsync();
        }

        public void UpdateCategory( Category category ) {
            Update( category );
        }
    }
}
