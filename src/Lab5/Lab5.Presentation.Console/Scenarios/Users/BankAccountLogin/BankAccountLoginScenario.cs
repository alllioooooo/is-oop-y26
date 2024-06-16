using Lab5.Domain.Contracts.BankAccounts;
using Lab5.Presentation.Console.Scenarios.Users.BankAccountChoice;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.BankAccountLogin;

public class BankAccountLoginScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;
    private readonly BankAccountChoiceScenario _bankAccountChoiceScenario;

    public BankAccountLoginScenario(IBankAccountService bankAccountService, BankAccountChoiceScenario bankAccountChoiceScenario)
    {
        _bankAccountService = bankAccountService;
        _bankAccountChoiceScenario = bankAccountChoiceScenario;
    }

    public string Name => "Bank Account Login";

    public async void Run()
    {
        long accountNumber = AnsiConsole.Ask<long>("Enter your bank account number:");
        long pincode = AnsiConsole.Ask<long>("Enter your PIN:");

        BankAccountLoginResult result = await _bankAccountService.LoginAsync(accountNumber, pincode);

        switch (result)
        {
            case BankAccountLoginResult.Success:
                AnsiConsole.MarkupLine("[green]Login successful![/]");
                _bankAccountChoiceScenario.Run();
                break;
            case BankAccountLoginResult.NotFound:
                AnsiConsole.MarkupLine("[red]Account not found or incorrect user.[/]");
                AnsiConsole.MarkupLine("[yellow]Press any key to go back...[/]");
                System.Console.ReadKey(true);
                break;
            case BankAccountLoginResult.WrongPassword:
                AnsiConsole.MarkupLine("[red]Incorrect PIN.[/]");
                AnsiConsole.MarkupLine("[yellow]Press any key to go back...[/]");
                System.Console.ReadKey(true);
                break;
        }
    }
}