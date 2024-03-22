using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class UserType
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public IEnumerable<User> Users { get; set; }
    }
}
