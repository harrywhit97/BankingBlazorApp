using FluentValidation;
using System;
using Domain.Models;
using System.Collections.Generic;

namespace BankingAPI.Validation
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {

        public TransactionValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty()
                .NotEqual(DateTimeOffset.MinValue);

            RuleFor(x => x.Bank)
                .NotNull();

            RuleFor(x => x.Description)
                .NotNull()
                .Length(1, 255);

            RuleFor(x => x.Classification)
                .NotNull()
                .Length(0, 255);

            RuleFor(x => x.Amount)
                .GreaterThan(0.01m);

            RuleFor(x => x.Account)
                .NotNull();
        }
    }
}
