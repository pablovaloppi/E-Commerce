using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICustomValidator<T>
    {
        void DefineRules();
        void SetEntity( T entity );
        bool IsValid();
        string ErrorMessages();
    }
}
