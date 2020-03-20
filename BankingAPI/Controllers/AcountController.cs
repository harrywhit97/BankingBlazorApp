using BankingAPI.Abstract;
using BankingAPI.Validation;
using Domain.Models;

namespace BankingAPI.Controllers
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
