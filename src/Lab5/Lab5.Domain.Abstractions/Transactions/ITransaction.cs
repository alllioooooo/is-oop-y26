namespace Lab5.Domain.Abstractions.Transactions;

public interface ITransaction
{
    public long AccountNumber { get; }

    public long AccountTransaction { get; }
}