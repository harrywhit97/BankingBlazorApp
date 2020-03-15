using System;

namespace CsvReader
{
    public class CsvTransaction
    {
        public string Description { get; set; }
        public string Date { get; set; }
        public string Credit { get; set; }
        public string Debit { get; set; }
        public string Classification { get; set; }
    }
}
