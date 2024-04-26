using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Auth : ICustomEntity
    {
        public int Id { get; set; }
        public int? ShoppingCartId { get; set; }
        public string UserName { get; set; }
        public int UserTypeId { get; set; }
        public string Token { get; set; }

    }
}
