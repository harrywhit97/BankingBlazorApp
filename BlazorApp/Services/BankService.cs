using BlazorApp.Abstract;
using Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class BankService : GenericService<Bank>
    {
        public BankService(HostConfiguration hostConfiguration) : base(hostConfiguration)
        {
        }

        public override async Task<bool> AddEntityAsync(Bank bank)
        {
            bank.Accounts = new List<Account>();
            var json = JsonConvert.SerializeObject(bank);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PostAsync(ApiUrl, content);
            return response.IsSuccessStatusCode;
        }
    }
}
