using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int PurchaseCount { get; set; }

        public int UserTypeId { get; set; }
        public int? SellerId { get; set; }

        public UserType UserType { get; set; }
        public Seller? Seller { get; set; }

    }
}
