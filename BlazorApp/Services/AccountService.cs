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

        public override OdataQueryBuilder GetQueryBuilder()
        {
            var builder = base.GetQueryBuilder();
            builder.Expand.Add(nameof(Account.Bank));
            return builder;
        }
    }
}
