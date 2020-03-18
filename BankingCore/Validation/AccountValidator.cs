using FluentValidation;
using System;
using Domain.Models;
using System.Collections.Generic;

namespace BankingCore.Validation
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
