using Entities.Model;
using FluentValidation;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;

namespace Entities.Validators
{
    public class CategoryValidator : CustomValidator<Category>
    {
        private const int NAME_MINIMUM_LENGHT = 3;
        public CategoryValidator() {
        }
        public override void DefineRules() {
            RuleFor( category => category.Name )
                .NotEmpty().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor( category => category.Name )
                .MinimumLength( NAME_MINIMUM_LENGHT ).WithMessage( "{PropertyName} no puede ser menor a {MinLenght}." );
            ;
        }

    }
}
 