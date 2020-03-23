using BankingAPI.Abstract;
using BankingAPI.Validation;
using Domain.Models;

namespace BankingAPI.Controllers
{
    public class BankController : GenericController<Bank, BankValidator>
    {
        public BankController(BankingDbContext context, BankValidator validator)
            : base(context, validator)
        {
        }
    }
}
