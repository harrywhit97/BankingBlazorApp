using Domain.Abstract;
using Domain.Enums;
using System;

namespace Domain.Models
{
    public class Transaction : Entity
    {
        public string Description { get; set; }
        public Account Accounts { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal Amount { get; set; }
        public string Classification { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Location { get; set; }
    }
}
