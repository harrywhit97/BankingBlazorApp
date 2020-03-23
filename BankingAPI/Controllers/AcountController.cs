using BankingAPI.Abstract;
using BankingAPI.Validation;
using Domain.Models;

namespace BankingAPI.Controllers
{
    public class AccountController : GenericController<Account, AccountValidator>
    {
        public AccountController(BankingDbContext context, AccountValidator validator)
            : base(context, validator)
        {
        }
    }
}
