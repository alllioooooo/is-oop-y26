using Lab5.Domain.Contracts.Transactions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.DepositMoney;

public class DepositMoneyScenario : IScenario
{
    private readonly ITransactionService _transactionService;

    public DepositMoneyScenario(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public string Name => "Deposit Money";

    public async void Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter the amount to deposit:");

        DepositMoneyResult result = await _transactionService.DepositMoneyAsync(amount);

        if (result is DepositMoneyResult.Success)
        {
            AnsiConsole.MarkupLine("[green]Money deposited successfully![/]");
        }
        else if (result is DepositMoneyResult.InvalidAmount)
        {
            AnsiConsole.MarkupLine("[red]Invalid amount entered.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Unable to deposit money.[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Press any key to go back...[/]");
        System.Console.ReadKey(true);
    }
}
