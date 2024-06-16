namespace Lab5.Domain.Contracts.BankAccounts;

public abstract record CreateBankAccountResult
{
    public sealed record Success(long AccountNumber) : CreateBankAccountResult;

    public sealed record UserNotFound : CreateBankAccountResult;
}