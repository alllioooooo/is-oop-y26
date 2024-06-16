using Lab5.Domain.Abstractions.BankAccounts;
using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Abstractions.Transactions;
using Lab5.Domain.Contracts.BankAccounts;
using Lab5.Domain.Contracts.Transactions;
using Lab5.Domain.Models.Transactions;

namespace Lab5.Application.Transactions;

public class TransactionService : ITransactionService
{
    private readonly IBankAccountsRepository _bankAccountsRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICurrentBankAccountManager _currentBankAccountManager;

    public TransactionService(IBankAccountsRepository bankAccountsRepository, ITransactionRepository transactionRepository, ICurrentBankAccountManager currentBankAccountManager)
    {
        _bankAccountsRepository = bankAccountsRepository;
        _transactionRepository = transactionRepository;
        _currentBankAccountManager = currentBankAccountManager;
    }

    public async Task<DepositMoneyResult> DepositMoneyAsync(long amount)
    {
        if (amount <= 0)
        {
            return new DepositMoneyResult.InvalidAmount();
        }

        IBankAccount? bankAccount = _currentBankAccountManager.BankAccount;
        if (bankAccount == null)
        {
            return new DepositMoneyResult.AccountNotFound();
        }

        await _transactionRepository.AddTransactionAsync(new Transaction(bankAccount.AccountNumber, amount));
        return new DepositMoneyResult.Success();
    }

    public async Task<ViewBalanceResult> ViewBalanceAsync()
    {
        IBankAccount? bankAccount = _currentBankAccountManager.BankAccount;
        if (bankAccount == null)
        {
            return new ViewBalanceResult.AccountNotFound();
        }

        IEnumerable<ITransaction> transactions = await _transactionRepository.FindTransactionsByAccountNumberAsync(bankAccount.AccountNumber);
        long balance = transactions.Sum(t => t.AccountTransaction);
        return new ViewBalanceResult.Success(balance);
    }

    public async Task<ViewTransactionsResult> ViewTransactionsAsync()
    {
        IBankAccount? bankAccount = _currentBankAccountManager.BankAccount;
        if (bankAccount == null)
        {
            return new ViewTransactionsResult.AccountNotFound();
        }

        IEnumerable<ITransaction> transactions = await _transactionRepository.FindTransactionsByAccountNumberAsync(bankAccount.AccountNumber);
        return new ViewTransactionsResult.Success(transactions);
    }

    public async Task<WithdrawMoneyResult> WithdrawMoneyAsync(long amount)
    {
        if (amount <= 0)
        {
            return new WithdrawMoneyResult.InvalidAmount();
        }

        IBankAccount? bankAccount = _currentBankAccountManager.BankAccount;
        if (bankAccount == null)
        {
            return new WithdrawMoneyResult.AccountNotFound();
        }

        ViewBalanceResult balanceResult = await ViewBalanceAsync();
        if (balanceResult is ViewBalanceResult.Success successResult)
        {
            decimal balance = successResult.Balance;
            if (balance < amount)
            {
                return new WithdrawMoneyResult.InsufficientFunds();
            }

            await _transactionRepository.AddTransactionAsync(new Transaction(bankAccount.AccountNumber, -amount));
            return new WithdrawMoneyResult.Success();
        }

        return new WithdrawMoneyResult.AccountNotFound();
    }
}