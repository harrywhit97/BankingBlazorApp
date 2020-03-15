using BankingCore.Abstract;
using Domain;
using Domain.Models;

namespace BankingCore.Controllers
{
    public class AccountController : GenericController<Account>
    {
        public AccountController(EFDbContext context)
            : base(context)
        {
        }
    }
}
