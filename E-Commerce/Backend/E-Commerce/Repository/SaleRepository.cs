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
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        public SaleRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
        }

        public void CreateSale( Sale sale ) {
            Create( sale );
        }

        public void DeleteSale( Sale sale ) {
            Delete( sale );
        }

        public async Task<IEnumerable<Sale>> GetAllAsync() {
            return await Get().ToListAsync();
        }

        public async Task<Sale> GetByIdAsync( int id ) {
            return await FindByCondition( sale => sale.Id == id ).FirstOrDefaultAsync();
        }

        public void UpdateSale( Sale sale ) {
            Update( sale );
        }
    }
}
