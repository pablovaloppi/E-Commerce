using Entities.Model;
using FluentValidation;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class CategoryValidator : AbstractValidator<Category>, ICustomValidator<Category>
    {
        Category _category;
        public CategoryValidator(Category category) {
            _category = category;
            RuleFor(x => x.Name).NotEmpty();
        }

        public string ErrorMessages(  ) {
            return Validate( _category ).ToString( "/n" );
        }

        public bool IsValid( ) {
            return Validate( _category ).IsValid;
        }
    }
}
 