using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c=>c.CompanyName).NotEmpty();
            RuleFor(c=>c.CompanyName).MinimumLength(4);
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.UserId).Must(NotBeZero).WithMessage("UserId sıfır olmamalıdır");
        }

        private bool NotBeZero(int arg)
        {
            if (arg == 0)
            {
                return false;
            }
            return true;
        }
    }
}
