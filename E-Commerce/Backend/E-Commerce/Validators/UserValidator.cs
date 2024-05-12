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
    public class UserValidator : CustomValidator<User>
    {
        private const int MIN_LENGHT_PASSWORD = 6;
        public override void DefineRules() {
            RuleFor( user => user.UserName )
                .NotEmpty().WithMessage( "{PropertyName} no puede estar vacio." );

            RuleFor( user => user.Password )
                .NotEmpty().WithMessage( "{PropertyName} no puede estar vacio." )
                .MinimumLength( MIN_LENGHT_PASSWORD ).WithMessage( "{PropertyName} " + " debe ser mayor a {MINIMUN_QUANTITY}." );

            RuleFor( user => user.Name )
                .NotEmpty().WithMessage( "{PropertyName} no puede estar vacio." );

            RuleFor( user => user.LastName )
                .NotEmpty().WithMessage( "{PropertyName} no puede estar vacio." );

            RuleFor( user => user.Address )
                .NotEmpty().WithMessage( "{PropertyName} no puede estar vacio." );

            RuleFor( user => user.Email )
                .NotEmpty().WithMessage( "{PropertyName} no puede estar vacio." )
                .EmailAddress();

            //RuleFor( user => user.DateOfBirth )
              //  .NotEmpty().WithMessage( "{PropertyName} no puede estar vacio." );

        }
    }
}
