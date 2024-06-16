using Lab5.Presentation.Console.Scenarios.Users.AddBankAccount;
using Lab5.Presentation.Console.Scenarios.Users.BankAccountLogin;
using Lab5.Presentation.Console.Scenarios.Users.Logout;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.UserChoice;

public class UserChoiceScenario : IScenario
{
    private readonly AddBankAccountScenario _addBankAccountScenario;
    private readonly BankAccountLoginScenario _bankAccountLogin;
    private readonly UserLogoutScenario _userLogoutScenario;

    public UserChoiceScenario(AddBankAccountScenario addBankAccountScenario, BankAccountLoginScenario bankAccountLogin, UserLogoutScenario userLogoutScenario)
    {
        _addBankAccountScenario = addBankAccountScenario;
        _bankAccountLogin = bankAccountLogin;
        _userLogoutScenario = userLogoutScenario;
    }

    public string Name => "User Options";

    public void Run()
    {
        string scenario = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices(new[] { "Add Bank Account", "Bank Account Login", "Logout" }));

        switch (scenario)
        {
            case "Add Bank Account":
                _addBankAccountScenario.Run();
                break;
            case "Bank Account Login":
                _bankAccountLogin.Run();
                break;
            case "Logout":
                _userLogoutScenario.Run();
                break;
            default:
                AnsiConsole.MarkupLine("[red]Invalid option selected[/]");
                break;
        }
    }
}