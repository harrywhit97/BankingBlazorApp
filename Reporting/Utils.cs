using Domain.Enums;
using Domain.Models;

namespace ReportingService
{
    public static class Utils
    {
        public static decimal GetSignedAmount(Transaction transaction)
        {
            return transaction.TransactionType == TransactionType.Credit ? transaction.Amount : -transaction.Amount;
        }
    }
}
