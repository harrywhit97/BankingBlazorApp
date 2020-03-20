using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BankingAPI.Abstract;
using BankingAPI.Validation;
using BankingAPI.Controllers;
using BankingAPI;

namespace BankingAPI.Controllers
{
    [EnableCors()]
    public class TransactionController : GenericController<Transaction, TransactionValidator>
    {
        readonly AccountController AccountController;

        public TransactionController(BankingDbContext context, TransactionValidator validator, AccountController accountController)
            : base(context, validator)
        {
            AccountController = accountController;
        }

        [HttpPost("import"), DisableRequestSizeLimit]
        public async Task<IActionResult> ImportFiles(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                Console.WriteLine($"Importing file : {file.FileName}");
                List<Transaction> transactions = new List<Transaction>();

                using (var stream = file.OpenReadStream())
                {
                    transactions.AddRange(CsvReader.Reader.ReadFileStream(stream));
                }

                var account = GetAccount();

                for (int i = 0; i < transactions.Count; i++)
                {
                    transactions[i].Account = account;
                    transactions[i].Bank = account.Bank;
                }
                AddAll(transactions);
            }
            return Ok();
        }

        Account GetAccount()
        {
            var accountIdHeader = Request.Headers["AccountId"];

            if (string.IsNullOrEmpty(accountIdHeader))
                throw new Exception("Account id header can not be empty");

            if (!long.TryParse(accountIdHeader, out var accountId))
                throw new Exception($"Invalid account id : {accountIdHeader}");

             var account = AccountController.GetById(accountId);

            if (account is null)
                throw new Exception($"An account with the od if '{accountId}' count not be found");

            return account;
        }
    }
}
