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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ECommerceDbContext _eCommerceDbContext;

        public UserRepository( ECommerceDbContext eCommerceDbContext ) : base( eCommerceDbContext ) {
            _eCommerceDbContext = eCommerceDbContext;
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

        public async Task<User> GetByUserNameAsync( string userName ) {
            return await FindByCondition( user => user.UserName == userName ).FirstOrDefaultAsync();
        }

        public async Task<string> GetRoleUserAsync( User user ) {
            var result = await (from userType in _eCommerceDbContext.UsersTypes
                         join users in _eCommerceDbContext.Users
                         on userType.Id equals user.Id
                         where user.Id == users.Id
                         select userType.Type).FirstOrDefaultAsync();

            return result;
        }

        public  string GetRoleUser( User user ) {
            var result =   (from userType in _eCommerceDbContext.UsersTypes
                                 join users in _eCommerceDbContext.Users
                                 on userType.Id equals users.UserTypeId
                                 where user.Id == users.Id
                                 select userType.Type ).FirstOrDefault();

            return result;
        }

        public void UpdateUser( User user ) {
            Update( user );
        }
    }
}
