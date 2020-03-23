using Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlazorApp.Models
{
    public class BankAPIResponse
    {
        [JsonProperty("@odata.count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<Bank> Banks { get; set; }
    }
}