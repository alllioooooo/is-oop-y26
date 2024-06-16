using Lab5.Domain.Contracts.Admins;
using Lab5.Presentation.Console.Scenarios.RoleChoice;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admins.Logout;

public class AdminLogoutScenario : IScenario
{
    private readonly IAdminService _adminService;
    private readonly RoleChoiceScenario _roleChoiceScenario;

    public AdminLogoutScenario(IAdminService adminService, RoleChoiceScenario roleChoiceScenario)
    {
        _adminService = adminService;
        _roleChoiceScenario = roleChoiceScenario;
    }

    public string Name => "Logout";

    public void Run()
    {
        AnsiConsole.MarkupLine("[yellow]Are you sure you want to logout? [Press any key to confirm]");
        System.Console.ReadKey(true);

        _adminService.Logout();
        AnsiConsole.MarkupLine("[green]You have been logged out.[/]");

        _roleChoiceScenario.Run();
    }
}