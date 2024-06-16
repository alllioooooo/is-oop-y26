using Lab5.Domain.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admins.AddUser;

public class AddUserScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AddUserScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Add User";

    public async void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter a username for the new user:");

        UserCreationResult result = await _adminService.CreateUserAsync(username);

        AnsiConsole.MarkupLine("[yellow]Press any key to go back...[/]");
        System.Console.ReadKey(true);

        if (result is UserCreationResult.Success)
        {
            AnsiConsole.MarkupLine("[green]User added successfully![/]");
        }
        else if (result is UserCreationResult.UsernameAlreadyExists)
        {
            AnsiConsole.MarkupLine("[red]Username already exists![/]");
        }
    }
}