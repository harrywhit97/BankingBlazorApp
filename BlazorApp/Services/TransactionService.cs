using BlazorApp.Abstract;
using BlazorApp.Models;
using Domain.Models;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class TransactionService : GenericService<Transaction>
    {
        public TransactionService(HostConfiguration hostConfiguration) : base(hostConfiguration)
        {
        }

        public override Task<APIResponse<Transaction>> GetEntitiesAsync(string url = null, int top = 0, int skip = 0)
        {
            url = $"{ApiUrl}?$expand=account";
            return base.GetEntitiesAsync(url, top, skip);
        }
    }
}
