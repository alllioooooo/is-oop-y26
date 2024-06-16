namespace Lab5.Domain.Contracts.BankAccounts;

public interface IBankAccountService
{
    public Task<BankAccountLoginResult> LoginAsync(long accountNumber, long pincode);
    public Task<CreateBankAccountResult> CreateAccountAsync(long pincode);
    public void Logout();
}