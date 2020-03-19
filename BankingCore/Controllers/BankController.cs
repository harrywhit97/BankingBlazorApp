using BankingCore.Abstract;
using BankingCore.Validation;
using Domain;
using Domain.Models;

namespace BankingCore.Controllers
{
    public class BankController : GenericController<Bank, BankValidator>
    {
        public BankController(BankingDbContext context, BankValidator validator)
            : base(context, validator)
        {
        }
    }
}
