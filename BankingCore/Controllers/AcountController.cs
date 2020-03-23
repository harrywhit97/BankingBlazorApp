using BankingCore.Abstract;
using BankingCore.Validation;
using Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BankingCore.Controllers
{
    public class AccountController : GenericController<Account, AccountValidator>
    {
        public AccountController(BankingDbContext context, AccountValidator validator)
            : base(context, validator)
        {
        }
        
        //[HttpGet("{id}")]
        //public override Account GetById(long id)
        //{
        //    return Repository.Include(x => x.Bank)
        //                     .Where(x => x.Id == id).FirstOrDefaultAsync().Result;
        //}

        //[HttpGet]
        //public override IEnumerable<Account> GetAll()
        //{
        //    return Repository.Include(x => x.Bank)
        //                     .AsEnumerable();
        //}
    }
}
