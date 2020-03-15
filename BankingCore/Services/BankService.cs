using BankingCore.Abstract;
using BankingCore.Controllers;
using Domain.Models;

namespace BankingCore.Services
{
    public class BankService : GenericService<Bank>
    {
        public BankService(BankController controller) : base(controller)
        {
        }
    }
}
