using Entities.Model;
using Entities.Helpers;
using Entities.Parameters;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<PagedList<Category>> GetAllAsync( CategoryParameters parameters );
        Task<Category> GetByIdAsync(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);

    }
}
