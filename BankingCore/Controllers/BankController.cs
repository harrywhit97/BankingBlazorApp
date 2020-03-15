using BankingCore.Abstract;
using Domain;
using Domain.Models;

namespace BankingCore.Controllers
{
    public class BankController : GenericController<Bank>
    {
        public BankController(EFDbContext context)
            : base(context)
        {
        }
    }
}
