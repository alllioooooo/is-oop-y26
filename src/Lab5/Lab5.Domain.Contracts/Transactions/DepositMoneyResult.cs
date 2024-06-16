namespace Lab5.Domain.Contracts.Transactions;

public abstract record DepositMoneyResult
{
    public sealed record Success : DepositMoneyResult;
    public sealed record InvalidAmount : DepositMoneyResult;
    public sealed record AccountNotFound : DepositMoneyResult;
}