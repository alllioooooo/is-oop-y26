using Lab5.Presentation.Console.Scenarios;
using Lab5.Presentation.Console.Scenarios.Admins.AddUser;
using Lab5.Presentation.Console.Scenarios.Admins.AdminChoice;
using Lab5.Presentation.Console.Scenarios.Admins.ChangePassword;
using Lab5.Presentation.Console.Scenarios.Admins.Login;
using Lab5.Presentation.Console.Scenarios.Admins.Logout;
using Lab5.Presentation.Console.Scenarios.RoleChoice;
using Lab5.Presentation.Console.Scenarios.Users.AddBankAccount;
using Lab5.Presentation.Console.Scenarios.Users.BankAccountChoice;
using Lab5.Presentation.Console.Scenarios.Users.BankAccountLogin;
using Lab5.Presentation.Console.Scenarios.Users.DepositMoney;
using Lab5.Presentation.Console.Scenarios.Users.Login;
using Lab5.Presentation.Console.Scenarios.Users.Logout;
using Lab5.Presentation.Console.Scenarios.Users.UserChoice;
using Lab5.Presentation.Console.Scenarios.Users.ViewBalance;
using Lab5.Presentation.Console.Scenarios.Users.ViewTransactions;
using Lab5.Presentation.Console.Scenarios.Users.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection services)
    {
        services.AddScoped<ScenarioRunner>();

        services.AddScoped<AdminLoginScenario>();
        services.AddScoped<AddUserScenario>();
        services.AddScoped<ChangePasswordScenario>();
        services.AddScoped<AdminLogoutScenario>();
        services.AddScoped<AdminChoiceScenario>();

        services.AddScoped<UserLoginScenario>();
        services.AddScoped<AddBankAccountScenario>();
        services.AddScoped<BankAccountLoginScenario>();
        services.AddScoped<UserLogoutScenario>();
        services.AddScoped<UserChoiceScenario>();
        services.AddScoped<ViewBalanceScenario>();
        services.AddScoped<ViewTransactionScenario>();
        services.AddScoped<WithdrawMoneyScenario>();
        services.AddScoped<DepositMoneyScenario>();
        services.AddScoped<BankAccountChoiceScenario>();

        services.AddScoped<RoleChoiceScenarioProvider>(provider =>
            new RoleChoiceScenarioProvider(
                provider.GetRequiredService<UserLoginScenario>(),
                provider.GetRequiredService<AdminLoginScenario>()));

        services.AddScoped<RoleChoiceScenario>(provider =>
            new RoleChoiceScenario(
                provider.GetRequiredService<UserLoginScenario>(),
                provider.GetRequiredService<AdminLoginScenario>()));

        return services;
    }
}