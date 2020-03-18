using BankingCore.Abstract;
using BankingCore.Controllers;
using BankingCore.Validation;
using Domain.Models;

namespace BankingCore.Services
{
    public class BankService : GenericService<Bank, BankValidator>
    {
        public BankService(BankController controller) : base(controller)
        {
        }
    }
}
