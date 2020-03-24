using BlazorApp.Abstract;
using Domain.Models;

namespace BlazorApp.Services
{
    public class TransactionService : GenericService<Transaction>
    {
        public TransactionService(HostConfiguration hostConfiguration) : base(hostConfiguration)
        {
        }
    }
}
