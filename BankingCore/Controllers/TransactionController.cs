using BankingCore.Abstract;
using Domain;
using Domain.Models;

namespace BankingCore.Controllers
{
    public class TransactionController : GenericController<Bank>
    {
        public TransactionController(EFDbContext context)
            : base(context)
        {
        }
    }
}
