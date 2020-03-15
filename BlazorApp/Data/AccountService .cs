using Domain.Models;
using Domain.Controllers;
using BlazorApp.Abstract;
using System.Collections.Generic;

namespace BlazorApp.Data
{
    public class AccountService : GenericService<Account>
    {
        BankController BankController;

        public AccountService(AccountController controller, BankController bankController) : base(controller)
        {
            BankController = bankController;
        }

        public IEnumerable<Bank> GetBankList() => BankController.GetAll();
    }
}
