using FluentValidation;
using Domain.Models;

namespace BankingAPI.Validation
{
    public class AccountValidator : AbstractValidator<Account>
    {

        public AccountValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(1, 255);
        }
    }
}
