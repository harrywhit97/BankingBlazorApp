using Blazor.FileReader;
using BlazorApp.Abstract;
using Domain.Models;
using System.Net.Http;

namespace BlazorApp.Services
{
    public class TransactionService : GenericService<Transaction>
    {
        public TransactionService(HostConfiguration hostConfiguration) : base(hostConfiguration)
        {
        }
    }
}
