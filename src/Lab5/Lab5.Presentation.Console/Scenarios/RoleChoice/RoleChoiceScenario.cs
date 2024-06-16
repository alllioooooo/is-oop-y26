using Lab5.Presentation.Console.Scenarios.Admins.Login;
using Lab5.Presentation.Console.Scenarios.Users.Login;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.RoleChoice;

public class RoleChoiceScenario : IScenario
{
    private readonly UserLoginScenario _userLoginScenario;
    private readonly AdminLoginScenario _adminLoginScenario;

    public RoleChoiceScenario(UserLoginScenario userLoginScenario, AdminLoginScenario adminLoginScenario)
    {
        _userLoginScenario = userLoginScenario;
        _adminLoginScenario = adminLoginScenario;
    }

    public string Name => "Role Choice";

    public void Run()
    {
        string role = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Who are you?")
                .AddChoices(new[] { "User", "Admin" }));

        switch (role)
        {
            case "User":
                _userLoginScenario.Run();
                break;
            case "Admin":
                _adminLoginScenario.Run();
                break;
            default:
                AnsiConsole.MarkupLine("[red]Invalid role selected[/]");
                break;
        }
    }
}