using Lab5.Domain.Contracts.Transactions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly ITransactionService _transactionService;

    public WithdrawMoneyScenario(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public string Name => "Withdraw Money";

    public async void Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter the amount to withdraw:");

        WithdrawMoneyResult result = await _transactionService.WithdrawMoneyAsync(amount);

        if (result is WithdrawMoneyResult.Success)
        {
            AnsiConsole.MarkupLine("[green]Money withdrawn successfully![/]");
        }
        else if (result is WithdrawMoneyResult.InsufficientFunds)
        {
            AnsiConsole.MarkupLine("[red]Insufficient funds.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Unable to withdraw money.[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Press any key to go back...[/]");
        System.Console.ReadKey(true);
    }
}
