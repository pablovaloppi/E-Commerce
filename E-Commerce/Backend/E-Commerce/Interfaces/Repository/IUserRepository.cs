using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUserNameAsync( string userName );

        Task<string> GetRoleUserAsync( User user );
        string GetRoleUser( User user );
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
