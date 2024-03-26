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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
        }

        public void CreateUser( User user ) {
            Create( user );
        }

        public void DeleteUser( User user ) {
            Delete( user );
        }

        public async Task<IEnumerable<User>> GetAllAsync() {
            return await Get().ToListAsync();
        }

        public async Task<User> GetByIdAsync( int id ) {
            return await FindByCondition( user => user.Id == id ).FirstOrDefaultAsync();
        }

        public void UpdateUser( User user ) {
            Update( user );
        }
    }
}
