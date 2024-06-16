using Lab5.Domain.Abstractions.Transactions;

namespace Lab5.Domain.Models.Transactions;

public class Transaction : ITransaction
{
    public Transaction(long accountNumber, long accountTransaction)
    {
        AccountNumber = accountNumber;
        AccountTransaction = accountTransaction;
    }

    public long AccountNumber { get; }

    public long AccountTransaction { get; }
}