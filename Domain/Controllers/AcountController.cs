using Domain.Abstract;
using Domain.Models;

namespace Domain.Controllers
{
    public class AccountController : GenericController<Account>
    {
        public AccountController(EFDbContext context)
            : base(context)
        {
        }
    }
}
