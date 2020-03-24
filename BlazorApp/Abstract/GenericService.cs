using BlazorApp.Models;
using Domain.Abstract;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Abstract
{
    public abstract class GenericService<TEntity> where TEntity : Entity
    {
        readonly HostConfiguration HostConfiguration;
        readonly public string ApiUrl;

        public GenericService(HostConfiguration hostConfiguration)
        {
            HostConfiguration = hostConfiguration;
            ApiUrl = $"{HostConfiguration.BankAPIUrl}/api/{typeof(TEntity).Name}".ToLowerInvariant();
        }

        public virtual async Task<APIResponse<TEntity>> GetEntitiesAsync(int skip = 0, int count = 0, string url = null)
        {
            using var client = new HttpClient();
            var response = client.GetAsync(url ?? ApiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponse<TEntity>>(jsonString);
            }
            return new APIResponse<TEntity>();
        }

        public async Task<bool> DeleteEntityAsync(TEntity entity)
        {
            return await DeleteEntityAsync(entity.Id);
        }

        public async Task<bool> DeleteEntityAsync(long id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync($"{ApiUrl}/{id}");

            return response.IsSuccessStatusCode;
        }

        public virtual async Task<bool> AddEntityAsync(TEntity entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PostAsync(ApiUrl, content);
            return response.IsSuccessStatusCode;
        }
    }
}
