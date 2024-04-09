using Entities.Dto.Category;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public  interface IService<T>
    {
        public void IsNull( object entity, string message = null );

    }
}
