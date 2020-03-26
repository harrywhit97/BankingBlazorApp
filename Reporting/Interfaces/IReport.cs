using Domain.Models;
using System.Collections.Generic;

namespace ReportingService.Interfaces
{
    public interface IReport
    {
        IList<Point> GetData(IEnumerable<Transaction> transactions);
    }
}
