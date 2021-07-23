using CreditCardApi.Domain.Communications;
using FluentValidation;

namespace CreditCardApi.Validators
{
    public class InputRequestValidator : AbstractValidator<InputRequest>
    {
        public InputRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.CardNumber)
                .NotEmpty()
                .Matches(@"^[0-9]+$").WithMessage("CardNumber must be numeric.");
        }
    }
}
