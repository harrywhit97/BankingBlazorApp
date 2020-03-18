using BankingCore.Abstract;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BankingCore.Controllers
{
    [EnableCors()]
    public class TransactionController : GenericController<Transaction>
    {
        readonly AccountController AccountController;

        public TransactionController(EFDbContext context, AccountController accountController)
            : base(context)
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
