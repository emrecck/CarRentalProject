using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.Email).EmailAddress();
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).NotEmpty();
            //RuleFor(u => u.Email).Must(NotContainInvalidChar).WithMessage("E-mail adresi geçersiz karakterler içermemelidir. ( * / ? ( ) + ");
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).Must(Contain).WithMessage("Şifreniz en az şunlardan bir tane içermelidir; A,a,9 (not: bu ifadeler semboliktir !)");
        }

        private bool Contain(string arg)
        {
            if (!arg.Any(char.IsUpper) || !arg.Any(char.IsNumber) || !arg.Any(char.IsLower))
            {
                return false;
            }
            return true;
        }

        private bool NotContainInvalidChar(string arg)
        {
            if (arg.Contains("*") || arg.Contains("/") || arg.Contains("?") || arg.Contains("(") || arg.Contains(")") || arg.Contains("+"))
            {
                return false;
            }
            return true;
        }
    }
}
