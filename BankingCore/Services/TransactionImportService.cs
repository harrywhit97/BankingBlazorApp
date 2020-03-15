using BankingCore.Controllers;

namespace BankingCore.Services
{
    public class TransactionImportService
    {
        public AccountController AccountController { get; set; }

        public TransactionImportService(AccountController controller)
        {
            AccountController = controller;
        }
    }
}
