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
    public class ProductValidator : CustomValidator<Product>
    {
        private const int TITLE_MINIMUM_LENGHT = 10;
        private const int TITLE_MAXIMUM_LENGHT = 60;
        private const int PRICE_GREATER = 0;
        private const int AMOUNT_GREATER_EQUAL = 1;

        public ProductValidator(){    
        }
        public override void DefineRules() {
            RuleFor( product => product.Title )
                .NotEmpty().WithMessage( "{PropertyName} no puede ser nulo." )
                .MinimumLength( TITLE_MINIMUM_LENGHT ).WithMessage( "{PropertyName} debe ser mayor que {MinLength}." )
                .MaximumLength( TITLE_MAXIMUM_LENGHT ).WithMessage( "{PropertyName} menor que {MaxLenght} caracteres." );
            
            RuleFor( product => product.Price )
                .NotEmpty().WithMessage( "{PropertyName} no puede ser nulo." )
                .GreaterThan( PRICE_GREATER ).WithMessage( "{PropertyName} debe ser mayor a {ComparisonValue}." );
            
            RuleFor( product => product.Amount )
                .NotEmpty().WithMessage( "{PropertyName} no puede ser nulo." )
                .GreaterThanOrEqualTo( AMOUNT_GREATER_EQUAL ).WithMessage( "{PropertyName} debe ser mayor o igual a {ComparisonValue}." );
        }
    }
}
