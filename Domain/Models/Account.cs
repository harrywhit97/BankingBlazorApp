using Domain.Abstract;
using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Account : Entity
    {
        public string Name { get; set; }
        public virtual Bank Bank { get; set; }
        public TransactionType AccountType { get; set; }
        public decimal Balance { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
