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
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetAllAsync(ProductParameters parameters);
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByTitle( string title );
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
