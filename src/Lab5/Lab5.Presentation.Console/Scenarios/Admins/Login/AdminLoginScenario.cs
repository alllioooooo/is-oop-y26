using Lab5.Domain.Contracts.Admins;
using Lab5.Presentation.Console.Scenarios.Admins.AdminChoice;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admins.Login;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;
    private readonly AdminChoiceScenario _adminChoiceScenario;

    public AdminLoginScenario(IAdminService adminService, AdminChoiceScenario adminChoiceScenario)
    {
        _adminService = adminService;
        _adminChoiceScenario = adminChoiceScenario;
    }

    public string Name => "Admin Login";

    public async void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username:");
        string password = AnsiConsole.Prompt(new TextPrompt<string>("Enter your password:").Secret());

        AdminLoginResult result = await _adminService.LoginAsync(username, password);

        switch (result)
        {
            case AdminLoginResult.Success:
                AnsiConsole.MarkupLine("[green]Login successful![/]");
                break;
            case AdminLoginResult.NotFound:
                AnsiConsole.MarkupLine("[red]Admin not found![/]");
                break;
            case AdminLoginResult.WrongPassword:
                AnsiConsole.MarkupLine("[red]Wrong password![/]");
                break;
        }

        AnsiConsole.MarkupLine("[yellow]Press any key to continue...[/]");
        System.Console.ReadKey(true);

        if (result is AdminLoginResult.Success)
        {
            _adminChoiceScenario.Run();
        }
    }
}