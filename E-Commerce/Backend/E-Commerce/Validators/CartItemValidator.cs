using Entities.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class CartItemValidator : CustomValidator<CartItem>
    {
        private const int MINIMUN_QUANTITY = 1;

        public CartItemValidator() {}
        public override void DefineRules() {
            RuleFor( cartItem => cartItem.Quantity )
                .NotEmpty().WithMessage( "{PropertyName} no puede ser nulo." )
               .GreaterThanOrEqualTo( MINIMUN_QUANTITY ).WithMessage( "{PropertyName}" + " debe ser mayor a {MINIMUN_QUANTITY}." );
        }
    }
}
