using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Bank : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
