namespace Lab5.Domain.Contracts.Transactions;

public abstract record ViewBalanceResult
{
    public sealed record Success(decimal Balance) : ViewBalanceResult;
    public sealed record AccountNotFound : ViewBalanceResult;
}