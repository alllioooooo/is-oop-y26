using System.Threading.Tasks;
using Lab5.Application.Transactions;
using Lab5.Domain.Abstractions.BankAccounts;
using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Abstractions.Transactions;
using Lab5.Domain.Contracts.BankAccounts;
using Lab5.Domain.Contracts.Transactions;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.WithdrawMoneyAsyncTest;

public class WithdrawMoneyAsyncTest
{
    [Fact]
    public async Task WithdrawMoneyAsync_Error_WhenBalanceIsInsufficient()
    {
        IBankAccountsRepository? mockBankAccountsRepository = Substitute.For<IBankAccountsRepository>();
        ITransactionRepository? mockTransactionRepository = Substitute.For<ITransactionRepository>();
        IBankAccount? mockBankAccount = Substitute.For<IBankAccount>();
        ICurrentBankAccountManager? mockCurrentBankAccountManager = Substitute.For<ICurrentBankAccountManager>();
        mockCurrentBankAccountManager.BankAccount.Returns(mockBankAccount);

        var service = new TransactionService(mockBankAccountsRepository, mockTransactionRepository, mockCurrentBankAccountManager);

        await service.DepositMoneyAsync(300);
        await mockTransactionRepository.Received(1).AddTransactionAsync(Arg.Is<ITransaction>(t => t.AccountTransaction == 300));

        long amountToWithdraw = 500;
        WithdrawMoneyResult withdrawResult = await service.WithdrawMoneyAsync(amountToWithdraw);

        Assert.IsType<WithdrawMoneyResult.InsufficientFunds>(withdrawResult);
        await mockTransactionRepository.DidNotReceive().AddTransactionAsync(Arg.Is<ITransaction>(t => t.AccountTransaction == -amountToWithdraw));
    }
}