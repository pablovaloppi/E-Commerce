using Entities.Dto.ShoppingCart;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int PurchaseCount { get; set; }

        public int UserTypeId { get; set; }
        public int? SellerId { get; set; }
        public int? ShoppingCartId { get; set; }

        public Seller? Seller { get; set; }
        public ShoppingCartDto ShoppingCart { get; set; }

    }
}
