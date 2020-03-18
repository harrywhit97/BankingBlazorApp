using BankingCore.Abstract;
using BankingCore.Validation;
using BankingCore.Controllers;
using Domain.Models;
using System.Collections.Generic;

namespace BankingCore.Services
{
    public class TransactionService : GenericService<Transaction, TransactionValidator>
    {
        readonly AccountController AccountController;

        public TransactionService(TransactionController controller, AccountController accountController) : base(controller)
        {
            AccountController = accountController;
        }

        public IEnumerable<Account> GetAllAcounts() => AccountController.GetAll();
    }
}
