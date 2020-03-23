using BlazorApp.Models;
using Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class BankService
    {
        const string baseUrl = "https://localhost:5003";

        public async Task<BankAPIResponse> GetBanksAsync(int skip = 0, int count = 0)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{baseUrl}/api/bank").Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<BankAPIResponse>(jsonString);
                }

                return new BankAPIResponse();
            }
        }

        public async Task<bool> DeleteBankAsync(Bank bank)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{baseUrl}/api/bank/{bank.Id}");

                 return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> AddBankAsync(Bank bank)
        {
            var json = JsonConvert.SerializeObject(bank);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"{baseUrl}/api/bank", content);

                return response.IsSuccessStatusCode;
            }
        }
    }
}
