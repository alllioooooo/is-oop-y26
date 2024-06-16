using Lab5.Domain.Contracts.Users;
using Lab5.Presentation.Console.Scenarios.RoleChoice;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.Logout;

public class UserLogoutScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly RoleChoiceScenario _roleChoiceScenario;

    public UserLogoutScenario(IUserService userService, RoleChoiceScenario roleChoiceScenario)
    {
        _userService = userService;
        _roleChoiceScenario = roleChoiceScenario;
    }

    public string Name => "Logout";

    public void Run()
    {
        _userService.Logout();
        AnsiConsole.MarkupLine("[green]You have been logged out.[/]");

        AnsiConsole.MarkupLine("[yellow]Press any key to continue...[/]");
        System.Console.ReadKey(true);

        _roleChoiceScenario.Run();
    }
}