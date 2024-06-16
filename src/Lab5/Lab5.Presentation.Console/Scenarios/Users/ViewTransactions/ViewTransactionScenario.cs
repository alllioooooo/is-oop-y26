using Lab5.Domain.Abstractions.Transactions;
using Lab5.Domain.Contracts.Transactions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.ViewTransactions;

public class ViewTransactionScenario : IScenario
{
    private readonly ITransactionService _transactionService;

    public ViewTransactionScenario(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public string Name => "View Transactions";

    public async void Run()
    {
        ViewTransactionsResult result = await _transactionService.ViewTransactionsAsync();

        if (result is ViewTransactionsResult.Success successResult)
        {
            foreach (ITransaction transaction in successResult.Transactions)
            {
                AnsiConsole.MarkupLine($"Amount: {transaction.AccountTransaction}");
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No transactions found or unable to view transactions.[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Press any key to go back...[/]");
        System.Console.ReadKey(true);
    }
}
