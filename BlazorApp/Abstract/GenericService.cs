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
            ApiUrl = $"{HostConfiguration.BankAPIUrl}/{typeof(TEntity).Name}".ToLowerInvariant();
        }

        public virtual async Task<APIResponse<TEntity>> GetEntitiesAsync(
            int top = 0, 
            int skip = 0, 
            bool getCount = true, 
            string filters = null, 
            string expands = null,
            string selects = null)
        {
            string requestUrl = ApiUrl;

            if (getCount)
                requestUrl = AddOdataQuerySegment(requestUrl, "$count=true");

            requestUrl = AddPageination(requestUrl, skip, top);
            requestUrl = AddOdataQuerySegment(requestUrl, filters);
            requestUrl = AddOdataQuerySegment(requestUrl, selects);
            requestUrl = AddOdataQuerySegment(requestUrl, expands);

            using var client = new HttpClient();
            var response = client.GetAsync(requestUrl).Result;

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

        public string AddOdataQuerySegment(string url, string segment)
        {
            if (segment is null)
                return url;

            var joinChar = url.Contains("?") ? "&" : "?";
            return $"{url}{joinChar}{segment}";
        }

        string AddPageination(string url, int skip, int top)
        {
            return top > 0
                ? AddOdataQuerySegment(url, $"$skip={skip}&$top={top}")
                : url;
        }
    }
}
