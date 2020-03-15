using Domain.Models;
using Domain.Controllers;
using BlazorApp.Abstract;

namespace BlazorApp.Data
{
    public class BankService : GenericService<Bank>
    {
        public BankService(BankController controller) : base(controller)
        {            
        }
    }
}
