using CsvHelper.Configuration;

namespace CsvReader
{
    public class CsvTransactionMap : ClassMap<CsvTransaction>
    {
        //public CsvTransactionMap(CsvTransactionColumnIndex map)
        //{
        //    Map(x => x.Description).Index(map.DescriptionColumn.ToString());
        //    Map(x => x.Date).Index(map.DateColumn.ToString());
        //    Map(x => x.Credit).Index(map.CreditColumn.ToString());
        //    Map(x => x.Debit).Index(map.DebitColumn.ToString());
        //    Map(x => x.Classification).Index(map.ClassificationColumn.ToString());
        //}

        public CsvTransactionMap()
        {

            Map(x => x.Date).Index(0);
            Map(x => x.Description).Index(1);
            Map(x => x.Credit).Index(6);
            Map(x => x.Debit).Index(5);
            Map(x => x.Classification).Index(4);
        }
    }
}
