using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllAsync();
        Task<UserType> GetByIdAsync(int id);
        void CreateUserType(UserType userType);
        void UpdateUserType(UserType userType);
        void DeleteUserType(UserType userType);
    }
}
