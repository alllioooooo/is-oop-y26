using Lab5.Domain.Contracts.BankAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.AddBankAccount;

public class AddBankAccountScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public AddBankAccountScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Add Bank Account";

    public async void Run()
    {
        long pincode = AnsiConsole.Ask<long>("Enter a PIN for your new bank account:");

        CreateBankAccountResult result = await _bankAccountService.CreateAccountAsync(pincode);

        AnsiConsole.MarkupLine("[yellow]Press any key to go back...[/]");
        System.Console.ReadKey(true);

        if (result is CreateBankAccountResult.Success success)
        {
            AnsiConsole.MarkupLine(
                $"[green]Bank account created successfully. Account Number: {success.AccountNumber}[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Failed to create bank account.[/]");
        }
    }
}