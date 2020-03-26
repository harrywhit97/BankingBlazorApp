using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReportingService
{
    public static class YearByCategory 
    {
        static public IList<Point> GetData(IEnumerable<Transaction> transactions)
        {
            var data = new List<Point>();

            var map = AggregateByCategory(transactions);

            foreach (var key in map.Keys)
                data.Add(new Point(key, map[key]));

            return data.OrderBy(x => x.Amount).ToList();
        }

        static decimal CalulateTotalSpends(IEnumerable<Transaction> transactions)
        {
            var total = 0.0m;

            foreach (var transaction in transactions)
            {
                total += Utils.GetSignedAmount(transaction);
            }
            return total;
        }

        public static Dictionary<string, decimal> AggregateByCategory(IEnumerable<Transaction> transactions)
        {
            var map = new Dictionary<string, decimal>();

            foreach (var transaction in transactions)
            {
                var key = transaction.Classification;

                if (string.IsNullOrEmpty(key))
                    continue;//key = "Misc";

                if (map.ContainsKey(key))
                    map[key] += Utils.GetSignedAmount(transaction);
                else
                    map.Add(key, Utils.GetSignedAmount(transaction));
            }
            return map;
        }
    }
}
