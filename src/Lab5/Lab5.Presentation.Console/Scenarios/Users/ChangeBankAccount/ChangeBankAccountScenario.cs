using Lab5.Presentation.Console.Scenarios.Users.UserChoice;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.ChangeBankAccount;

public class ChangeBankAccountScenario : IScenario
{
    private readonly UserChoiceScenario _userChoiceScenario;

    public ChangeBankAccountScenario(UserChoiceScenario userChoiceScenario)
    {
        _userChoiceScenario = userChoiceScenario;
    }

    public string Name => "Change Bank Account";

    public void Run()
    {
        AnsiConsole.MarkupLine("[yellow]Press any key to return to the user options...[/]");
        System.Console.ReadKey(true);

        _userChoiceScenario.Run();
    }
}
