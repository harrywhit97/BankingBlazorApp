using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace CsvReader
{
    public static class Reader
    {
        public static IList<Transaction> ReadFileStream(Stream stream)
        {
            var csvTrans = new List<CsvTransaction>();

            using (var reader = new StreamReader(stream))
            {
                using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.RegisterClassMap<CsvTransactionMap>();
                var records = csv.GetRecords<CsvTransaction>();
                csvTrans.AddRange(records);
            }
            return ConvertCsvTransactionToTransaction(csvTrans);
        }

        static IList<Transaction> ConvertCsvTransactionToTransaction(IList<CsvTransaction> csvTransactions)
        {
            var transactions = new List<Transaction>();
            foreach (var csvTransaction in csvTransactions)
	        {
                var transactionType = GetTransactionType(csvTransaction);                

                var transaction = new Transaction()
                {
                    Date = GetDate(csvTransaction.Date),
                    Description = csvTransaction.Description,
                    Classification = csvTransaction.Classification,
                    TransactionType = transactionType,
                    Amount = GetAbsoluteAmount(csvTransaction, transactionType)
                };

                transactions.Add(transaction);
	        }
            return transactions;
        }

        static DateTimeOffset GetDate(string stringDate)
        {
            if (!DateTimeOffset.TryParse(stringDate, out var date))
                throw new Exception($"'{stringDate}' could not be parsed to a DateTimeOffset.");
            return date;
        }

        static decimal GetAbsoluteAmount(CsvTransaction csvTransaction, TransactionType transactionType)
        {
            var amount = transactionType == TransactionType.Credit
                ? csvTransaction.Credit : csvTransaction.Debit;

            if (!decimal.TryParse(amount, out var value))
                throw new Exception($"'{amount}' is not a number.");
            return Math.Abs(value);
        }

        static TransactionType GetTransactionType(CsvTransaction transaction)
        {
            var isCredit = !string.IsNullOrEmpty(transaction.Credit);
            var isDebit = !string.IsNullOrEmpty(transaction.Debit);

            if (isCredit || isDebit)
            {
                if(isCredit && isDebit)
                    throw new Exception($"A transaction can only have either a credit amount or a debit amount");

                if(isCredit)
                    return TransactionType.Credit;
                return TransactionType.Debit;
            }
            else
                throw new Exception($"A transaction was found with out a credit or debit amount.");
        }
    }    
}
