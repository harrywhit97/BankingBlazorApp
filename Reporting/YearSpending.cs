using Domain.Enums;
using Domain.Models;
using Reporting.Enums;
using ReportingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportingService
{
    public class YearSpending : IReport
    {
        public IList<Point> GetData(IEnumerable<Transaction> transactions)
        {
            var data = new List<Point>();
            
            foreach (var month in Enum.GetValues(typeof(Month)))
            {
                var monthTransactions = transactions.Where(x => x.Date.Month == (int)month);
                var totalSpends = CalulateTotalSpends(monthTransactions);
                data.Add(new Point(month.ToString(), totalSpends));
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
    }
}
