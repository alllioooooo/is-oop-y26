using Lab5.Domain.Abstractions.Transactions;

namespace Lab5.Domain.Contracts.Transactions;

public abstract record ViewTransactionsResult
{
    public sealed record Success(IEnumerable<ITransaction> Transactions) : ViewTransactionsResult;
    public sealed record AccountNotFound : ViewTransactionsResult;
}