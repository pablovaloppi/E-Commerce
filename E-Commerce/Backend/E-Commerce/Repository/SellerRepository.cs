using Entities.Model;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
    {
        public SellerRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
        }

        public void CreateSeller( Seller seller ) {
            Create( seller );
        }

        public void DeleteSeller( Seller seller ) {
            Delete( seller );
        }

        public async Task<IEnumerable<Seller>> GetAllAsync() {
            return await Get().ToListAsync();
        }

        public async Task<Seller> GetByIdAsync( int id ) {
            return await FindByCondition( seller => seller.Id == id ).FirstOrDefaultAsync();
        }

        public void UpdateSeller( Seller seller ) {
            Update( seller );
        }
    }
}
