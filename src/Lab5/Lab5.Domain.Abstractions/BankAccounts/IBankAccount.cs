namespace Lab5.Domain.Abstractions.BankAccounts;

public interface IBankAccount
{
    public long UserId { get; }

    public long AccountNumber { get; }

    public long Pincode { get; }
}