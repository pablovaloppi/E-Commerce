using Entities.Model;
using FluentValidation;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class CustomValidator<T> : AbstractValidator<T>, ICustomValidator<T> {
        private T _entity;

        public CustomValidator() {
            DefineRules();
        }
        
        public virtual void DefineRules() {
        }

        public string ErrorMessages() {
            return Validate( _entity ).ToString("-");
        }

        public bool IsValid() {
            return Validate( _entity ).IsValid;
        }

        public void SetEntity( T entity ) {
            _entity = entity;
        }
    }
}
