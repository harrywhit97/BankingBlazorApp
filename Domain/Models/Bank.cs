using Domain.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Bank : Entity
    {
        [Required]
        public string Name { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
