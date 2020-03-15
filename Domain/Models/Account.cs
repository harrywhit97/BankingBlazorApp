using Domain.Abstract;
using Domain.Enums;

namespace Domain.Models
{
    public class Account : Entity
    {
        public string Name { get; set; }
        public string BankName { get; set; }
        public TransactionType AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
