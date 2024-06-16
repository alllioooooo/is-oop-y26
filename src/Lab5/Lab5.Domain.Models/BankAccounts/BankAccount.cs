using Lab5.Domain.Abstractions.BankAccounts;

namespace Lab5.Domain.Models.BankAccounts;

public class BankAccount : IBankAccount
{
    public BankAccount(long userId, long accountNumber, long pincode)
    {
        UserId = userId;
        AccountNumber = accountNumber;
        Pincode = pincode;
    }

    public long UserId { get; }

    public long AccountNumber { get; }

    public long Pincode { get; }
}