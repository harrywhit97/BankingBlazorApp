using Domain.Abstract;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Transaction : Entity
    {
        public string Description { get; set; }
        public Account Accounts { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Classification { get; set; }
    }
}
