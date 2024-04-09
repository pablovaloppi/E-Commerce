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

        public async Task<PagedList<Category>> GetAllAsync( CategoryParameters parameters) {
            
            return await PagedList<Category>.ToPagedListAsync(Get().OrderBy( c=> c.Name), parameters.PageNumber, parameters.PageSize); 
        }
        public async Task<Category> GetByIdAsync( int id ) {
            return await FindByCondition( category => category.Id == id ).FirstOrDefaultAsync();
        }

        public void UpdateCategory( Category category ) {
            Update( category );
        }
    }
}
