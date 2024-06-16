using Lab5.Domain.Abstractions.BankAccounts;

namespace Lab5.Domain.Contracts.BankAccounts;

public interface ICurrentBankAccountManager
{
    public IBankAccount? BankAccount { get; set; }
}