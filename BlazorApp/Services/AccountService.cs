using BlazorApp.Abstract;
using BlazorApp.Models;
using Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class AccountService : GenericService<Account>
    {
        public AccountService(HostConfiguration hostConfiguration) : base(hostConfiguration)
        {
        }
    }
}
