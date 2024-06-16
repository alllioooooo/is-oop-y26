using Lab5.Application.Admins;
using Lab5.Application.BankAccounts;
using Lab5.Application.Transactions;
using Lab5.Application.Users;
using Lab5.Domain.Contracts.Admins;
using Lab5.Domain.Contracts.BankAccounts;
using Lab5.Domain.Contracts.Transactions;
using Lab5.Domain.Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<ICurrentAdminManager, CurrentAdminManager>();

        collection.AddScoped<IBankAccountService, BankAccountService>();
        collection.AddScoped<ICurrentBankAccountManager, CurrentBankAccountManager>();

        collection.AddScoped<ITransactionService, TransactionService>();

        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<ICurrentUserManager, CurrentUserManager>();

        return collection;
    }
}
