namespace Lab5.Domain.Contracts.BankAccounts;

public abstract record BankAccountLoginResult
{
    private BankAccountLoginResult() { }

    public sealed record Success : BankAccountLoginResult;

    public sealed record NotFound : BankAccountLoginResult;

    public sealed record WrongPassword : BankAccountLoginResult;
}