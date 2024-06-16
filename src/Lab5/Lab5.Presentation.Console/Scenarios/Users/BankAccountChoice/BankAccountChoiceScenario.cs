using Lab5.Presentation.Console.Scenarios.Users.ChangeBankAccount;
using Lab5.Presentation.Console.Scenarios.Users.DepositMoney;
using Lab5.Presentation.Console.Scenarios.Users.ViewBalance;
using Lab5.Presentation.Console.Scenarios.Users.ViewTransactions;
using Lab5.Presentation.Console.Scenarios.Users.WithdrawMoney;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.BankAccountChoice;

public class BankAccountChoiceScenario : IScenario
{
    private readonly ViewBalanceScenario _viewBalanceScenario;
    private readonly DepositMoneyScenario _depositMoneyScenario;
    private readonly WithdrawMoneyScenario _withdrawMoneyScenario;
    private readonly ViewTransactionScenario _viewTransactionScenario;
    private readonly ChangeBankAccountScenario _changeBankAccountScenario;

    public BankAccountChoiceScenario(
        ViewBalanceScenario viewBalanceScenario,
        DepositMoneyScenario depositMoneyScenario,
        WithdrawMoneyScenario withdrawMoneyScenario,
        ViewTransactionScenario viewTransactionScenario,
        ChangeBankAccountScenario changeBankAccountScenario)
    {
        _viewBalanceScenario = viewBalanceScenario;
        _depositMoneyScenario = depositMoneyScenario;
        _withdrawMoneyScenario = withdrawMoneyScenario;
        _viewTransactionScenario = viewTransactionScenario;
        _changeBankAccountScenario = changeBankAccountScenario;
    }

    public string Name => "Bank Account Options";

    public void Run()
    {
        string action = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices(new[]
                {
                    "View Balance",
                    "Deposit Money",
                    "Withdraw Money",
                    "View Transactions",
                    "Change Bank Account",
                }));

        switch (action)
        {
            case "View Balance":
                _viewBalanceScenario.Run();
                break;
            case "Deposit Money":
                _depositMoneyScenario.Run();
                break;
            case "Withdraw Money":
                _withdrawMoneyScenario.Run();
                break;
            case "View Transactions":
                _viewTransactionScenario.Run();
                break;
            case "Change Bank Account":
                _changeBankAccountScenario.Run();
                break;
            default:
                AnsiConsole.MarkupLine("[red]Invalid option selected[/]");
                break;
        }
    }
}