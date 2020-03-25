using BlazorApp.Abstract;
using BlazorApp.Models;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class TransactionService : GenericService<Transaction>
    {
        public TransactionService(HostConfiguration hostConfiguration) : base(hostConfiguration)
        {
        }

        public override Task<APIResponse<Transaction>> GetEntitiesAsync(int top = 0, int skip = 0, bool getCount = true, string filters = null, string expands = null, string selects = null)
        {
            var expandAccount = "$expand=account";

            expands = expands is null ? expandAccount : $"{expands}&{expandAccount}";

            return base.GetEntitiesAsync(top, skip, getCount, filters, expands, selects);
        }

        public async Task<List<string>> GetClassificationsAsync()
        {
            var select = $"$select=classification";

            var response = await base.GetEntitiesAsync(selects: select);

            var classifications = new List<string>() { "" };

            foreach (var category in response.Entities.Select(x => x.Classification))
            {
                if (!classifications.Contains(category))
                    classifications.Add(category);
            }
            return classifications;
        }
    
    
        public async Task<APIResponse<Transaction>> GetEntitiesWithFilters(string classification = null, int skip = 0, int top = 0)
        {
            if (string.IsNullOrEmpty(classification))
                return await GetEntitiesAsync(skip: skip, top: top);
            
            var filter = $"$filter={nameof(classification)} eq '{classification}'";

            return await GetEntitiesAsync(skip: skip, top: top, filters: filter);
        }
    }
}
