using Lab5.Domain.Abstractions.Transactions;

namespace Lab5.Domain.Abstractions.Repositories;

public interface ITransactionRepository
{
    public Task AddTransactionAsync(ITransaction transaction);

    public Task<IEnumerable<ITransaction>> FindTransactionsByAccountNumberAsync(long accountNumber);
}