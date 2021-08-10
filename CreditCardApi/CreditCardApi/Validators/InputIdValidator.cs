using CreditCardApi.Domain.Communications;
using FluentValidation;
using System;

namespace CreditCardApi.Validators
{
    public class InputIdValidator : AbstractValidator<string>
    {
        public InputIdValidator()
        {
                RuleFor(x => x)
                .NotEmpty()
                .Must(x => IsValidGuid(x)).WithMessage("Input id invalid");
        }

        public bool IsValidGuid(string id)
        {
            return (Guid.TryParse(id, out var guidId) && guidId != Guid.Empty);
        }
    }
}
