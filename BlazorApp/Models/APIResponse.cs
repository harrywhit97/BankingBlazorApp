using Domain.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlazorApp.Models
{
    public class APIResponse<TEntity> where TEntity : Entity
    {
        [JsonProperty("@odata.count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<TEntity> Entities { get; set; }
    }
}