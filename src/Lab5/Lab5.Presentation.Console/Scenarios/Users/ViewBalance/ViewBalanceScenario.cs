using Lab5.Domain.Contracts.Transactions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.ViewBalance;

public class ViewBalanceScenario : IScenario
{
    private readonly ITransactionService _transactionService;

    public ViewBalanceScenario(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public string Name => "View Balance";

    public async void Run()
    {
        ViewBalanceResult result = await _transactionService.ViewBalanceAsync();

        if (result is ViewBalanceResult.Success success)
        {
            AnsiConsole.MarkupLine($"[blue]Your current balance is: {success.Balance}[/]");
        }
        else if (result is ViewBalanceResult.AccountNotFound)
        {
            AnsiConsole.MarkupLine("[red]Account not found.[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Press any key to go back...[/]");
        System.Console.ReadKey(true);
    }
}