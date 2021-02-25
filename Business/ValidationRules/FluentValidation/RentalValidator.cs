using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CarId).GreaterThan(0);
            RuleFor(r => r.CarId).LessThanOrEqualTo(8);
            RuleFor(r => r.CustomerID).NotEmpty();
            RuleFor(r => r.CustomerID).GreaterThan(0);
            RuleFor(r => r.CustomerID).LessThanOrEqualTo(3);
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).Must(NotAtFuture).WithMessage("Kiralama tarihi bugünden ileri olamaz");
            RuleFor(r => r.ReturnDate).Must(NotAtPast);
        }

        private bool NotAtPast(DateTime? arg)
        {
            if (arg < DateTime.Now)
            {
                return false;
            }
            return true;
        }

        private bool NotAtFuture(DateTime arg)
        {
            if (arg > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
