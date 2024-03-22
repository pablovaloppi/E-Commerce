using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Seller
    {
        public  int Id { get; set; }
        public int SalesQuantity { get; set; }

        public IEnumerable<User> Users  { get; set; }
    }
}
