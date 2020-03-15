using Domain.Abstract;
using Domain.Models;

namespace Domain.Controllers
{
    public class BankController : GenericController<Bank>
    {
        public BankController(EFDbContext context)
            : base(context)
        {
        }
    }
}
