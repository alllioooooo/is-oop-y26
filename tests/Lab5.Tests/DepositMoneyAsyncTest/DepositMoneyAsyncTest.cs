using System.Threading.Tasks;
using Lab5.Application.Transactions;
using Lab5.Domain.Abstractions.BankAccounts;
using Lab5.Domain.Abstractions.Repositories;
using Lab5.Domain.Abstractions.Transactions;
using Lab5.Domain.Contracts.BankAccounts;
using Lab5.Domain.Contracts.Transactions;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.DepositMoneyAsyncTest;

public class DepositMoneyAsyncTest
{
    [Fact]
    public async Task DepositMoneyAsync_Success_WhenAmountIsValid()
    {
        IBankAccountsRepository?
            mockBankAccountsRepository = Substitute.For<IBankAccountsRepository>(); // Мок для IBankAccountsRepository
        ITransactionRepository? mockTransactionRepository = Substitute.For<ITransactionRepository>();
        IBankAccount? mockBankAccount = Substitute.For<IBankAccount>();
        ICurrentBankAccountManager? mockCurrentBankAccountManager = Substitute.For<ICurrentBankAccountManager>();
        mockCurrentBankAccountManager.BankAccount.Returns(mockBankAccount);

        var service = new TransactionService(mockBankAccountsRepository, mockTransactionRepository, mockCurrentBankAccountManager);

        DepositMoneyResult result = await service.DepositMoneyAsync(500);

        Assert.IsType<DepositMoneyResult.Success>(result);
        await mockTransactionRepository.Received(1).AddTransactionAsync(Arg.Any<ITransaction>());
    }
}