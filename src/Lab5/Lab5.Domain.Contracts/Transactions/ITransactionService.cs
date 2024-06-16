namespace Lab5.Domain.Contracts.Transactions;

public interface ITransactionService
{
    public Task<DepositMoneyResult> DepositMoneyAsync(long amount);
    public Task<ViewBalanceResult> ViewBalanceAsync();
    public Task<ViewTransactionsResult> ViewTransactionsAsync();
    public Task<WithdrawMoneyResult> WithdrawMoneyAsync(long amount);
}