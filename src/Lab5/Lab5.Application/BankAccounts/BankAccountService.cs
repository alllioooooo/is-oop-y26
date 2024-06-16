using Lab5.Application.Users;
using Lab5.Domain.Abstractions.BankAccounts;
using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Contracts.BankAccounts;
using Lab5.Domain.Models.BankAccounts;

namespace Lab5.Application.BankAccounts;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountsRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public BankAccountService(IBankAccountsRepository repository, CurrentUserManager currentUserManager, CurrentBankAccountManager currentBankAccountManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
        CurrentBankAccountManager = currentBankAccountManager;
    }

    public CurrentBankAccountManager CurrentBankAccountManager { get; set; }

    public async Task<BankAccountLoginResult> LoginAsync(long accountNumber, long pincode)
    {
        if (_currentUserManager.User == null)
        {
            return new BankAccountLoginResult.NotFound();
        }

        long userId = _currentUserManager.User.Id;

        IBankAccount? bankAccount = await _repository.FindAccountByNumberAsync(accountNumber);

        if (bankAccount == null || bankAccount.UserId != userId)
        {
            return new BankAccountLoginResult.NotFound();
        }

        if (bankAccount.Pincode != pincode)
        {
            return new BankAccountLoginResult.WrongPassword();
        }

        CurrentBankAccountManager.BankAccount = bankAccount;
        return new BankAccountLoginResult.Success();
    }

    public async Task<CreateBankAccountResult> CreateAccountAsync(long pincode)
    {
        if (_currentUserManager.User == null)
        {
            return new CreateBankAccountResult.UserNotFound();
        }

        long userId = _currentUserManager.User.Id;
        long newAccountNumber = GenerateNewAccountNumber();

        var newBankAccount = new BankAccount(userId, newAccountNumber, pincode);
        await _repository.AddAccountAsync(newBankAccount);

        return new CreateBankAccountResult.Success(newAccountNumber);
    }

    public void Logout()
    {
        CurrentBankAccountManager.BankAccount = null;
    }

    private static long GenerateNewAccountNumber()
    {
        var guid = Guid.NewGuid();
        return BitConverter.ToInt64(guid.ToByteArray(), 0);
    }
}