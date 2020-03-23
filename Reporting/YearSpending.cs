using Domain.Enums;
using Domain.Models;
using Reporting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reporting
{
    public class YearSpending
    {
        public IList<Point> GetData(IEnumerable<Transaction> transactionsForYear)
        {
            var data = new List<Point>();
            
            foreach (var month in Enum.GetValues(typeof(Month)))
            {
                var monthTransactions = transactionsForYear.Where(x => x.Date.Month == (int)month);
                var totalSpends = CalulateTotalSpends(monthTransactions);
                data.Add(new Point((Month)month, totalSpends));
            }
            return data;
        }

        decimal CalulateTotalSpends(IEnumerable<Transaction> transactions)
        {
            var total = 0.0m;

            foreach (var transaction in transactions)
            {
                total += transaction.TransactionType == TransactionType.Credit ? transaction.Amount : -transaction.Amount;
            }
            return total;
        }

        public class Point
        {
            public Month Month { get; set; }
            public decimal Amount { get; set; }

            public Point(Month month, decimal amount) =>
                (Month, Amount) = (month, amount);

        }
    }
}
