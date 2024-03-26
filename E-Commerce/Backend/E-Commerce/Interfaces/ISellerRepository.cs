using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> GetAllAsync();
        Task<Seller> GetByIdAsync(int id);
        void CreateSeller( Seller seller );
        void UpdateSeller( Seller seller );
        void DeleteSeller( Seller seller );
    }
}
