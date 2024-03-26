using Entities.Model;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync( int id );
        void CreateCategory(Category category );
        void UpdateCategory( Category category );
        void DeleteCategory( Category category );
     
    }
}
