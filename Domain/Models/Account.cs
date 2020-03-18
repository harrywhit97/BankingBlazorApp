using Domain.Abstract;
using Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Account : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Bank Bank { get; set; }
        [Required]
        public TransactionType AccountType { get; set; }
        [Required]
        public decimal Balance { get; set; }
        public IList<Transaction> Transactions { get; set; }
    }
}
