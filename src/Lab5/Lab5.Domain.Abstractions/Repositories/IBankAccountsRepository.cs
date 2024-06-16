using Lab5.Domain.Abstractions.BankAccounts;

namespace Lab5.Domain.Abstractions.Repositories;

public interface IBankAccountsRepository
{
    public Task<IBankAccount?> FindAccountByUserIdAsync(long userId);

    public Task AddAccountAsync(IBankAccount account);

    public Task<IBankAccount?> FindAccountByNumberAsync(long accountNumber);
}