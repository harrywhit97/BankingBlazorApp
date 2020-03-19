using BankingCore.Abstract;
using BankingCore.Validation;
using BankingCore.Controllers;
using Domain.Models;
using System.Collections.Generic;

namespace BankingCore.Services
{
    public class AccountService : GenericService<Account, AccountValidator>
    {
        BankController BankController;

        public AccountService(AccountController controller, BankController bankController) : base(controller)
        {
            BankController = bankController;
        }

        public IEnumerable<Bank> GetBankList() => BankController.GetAll();
        public Bank GetBankById(long id) => BankController.GetById(id);
    }
}
