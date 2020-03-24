using BlazorApp.Abstract;
using Domain.Models;

namespace BlazorApp.Services
{
    public class AccountService : GenericService<Account>
    {
        public AccountService(HostConfiguration hostConfiguration) : base(hostConfiguration)
        {
        }
    }
}
