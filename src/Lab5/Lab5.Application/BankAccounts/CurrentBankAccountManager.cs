using Lab5.Domain.Abstractions.BankAccounts;
using Lab5.Domain.Contracts.BankAccounts;

namespace Lab5.Application.BankAccounts;

public class CurrentBankAccountManager : ICurrentBankAccountManager
{
    public IBankAccount? BankAccount { get; set; }
}