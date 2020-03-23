using FluentValidation;
using Domain.Models;

namespace BankingAPI.Validation
{
    public class BankValidator : AbstractValidator<Bank>
    {

        public BankValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(1, 255);
        }
    }
}
