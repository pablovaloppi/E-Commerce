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
    public class UserTypeRepository : RepositoryBase<UserType>, IUserTypeRepository
    {
        public UserTypeRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
        }

        public void CreateUserType( UserType userType ) {
            Create( userType );
        }

        public void DeleteUserType( UserType userType ) {
            Delete( userType );
        }

        public async Task<IEnumerable<UserType>> GetAllAsync() {
            return await Get().ToListAsync();
        }

        public async Task<UserType> GetByIdAsync( int id ) {
            return await FindByCondition( usertype => usertype.Id == id ).FirstOrDefaultAsync();
        }

        public void UpdateUserType( UserType userType ) {
            Update( userType );
        }
    }
}
