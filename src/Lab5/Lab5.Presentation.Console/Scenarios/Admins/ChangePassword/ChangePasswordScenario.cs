using Lab5.Domain.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admins.ChangePassword;

public class ChangePasswordScenario : IScenario
{
    private readonly IAdminService _adminService;

    public ChangePasswordScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Change Password";

    public async void Run()
    {
        string newPassword = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your new password:")
                .Secret());

        if (_adminService.CurrentAdminManager.Admin == null)
        {
            AnsiConsole.MarkupLine("[red]You are not logged in as an admin.[/]");
            return;
        }

        AdminPasswordChangeResult result = await _adminService.ChangePasswordAsync(_adminService.CurrentAdminManager.Admin.Username, newPassword);

        AnsiConsole.MarkupLine("[yellow]Press any key to go back...[/]");
        System.Console.ReadKey(true);

        if (result is AdminPasswordChangeResult.Success)
        {
            AnsiConsole.MarkupLine("[green]Password changed successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Failed to change password.[/]");
        }
    }
}
