namespace Lab5.Domain.Contracts.Transactions;

public abstract record WithdrawMoneyResult
{
    public sealed record Success : WithdrawMoneyResult;
    public sealed record InvalidAmount : WithdrawMoneyResult;
    public sealed record InsufficientFunds : WithdrawMoneyResult;
    public sealed record AccountNotFound : WithdrawMoneyResult;
}