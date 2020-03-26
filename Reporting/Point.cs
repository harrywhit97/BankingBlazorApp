using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingService
{
    public class Point
    {
        public string Selector { get; set; }
        public decimal Amount { get; set; }

        public Point(string selector, decimal amount) =>
            (Selector, Amount) = (selector, amount);
    }
}
