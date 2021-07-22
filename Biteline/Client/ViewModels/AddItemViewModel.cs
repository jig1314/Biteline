using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biteline.Client.ViewModels
{
    public class AddItemViewModel
    {
        public string Name { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int Quantity { get; set; }
    }

    public class AddItemValidator : AbstractValidator<AddItemViewModel>
    {
        public AddItemValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Please enter a food item name.");

            RuleFor(x => x.ExpirationDate).Must(ValidDate)
                .WithMessage("Please enter a valid expiration date");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Please enter a valid quantity.")
                .GreaterThan(0)
                .WithMessage("Please enter a valid quantity.");
        }

        private bool ValidDate(DateTime? date)
        {
            return date.HasValue;
        }
    }
}
