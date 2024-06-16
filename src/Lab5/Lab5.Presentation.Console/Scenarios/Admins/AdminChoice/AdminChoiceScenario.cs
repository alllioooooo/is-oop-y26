using Lab5.Presentation.Console.Scenarios.Admins.AddUser;
using Lab5.Presentation.Console.Scenarios.Admins.ChangePassword;
using Lab5.Presentation.Console.Scenarios.Admins.Logout;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admins.AdminChoice;

public class AdminChoiceScenario : IScenario
{
    private readonly AddUserScenario _addUserScenario;
    private readonly ChangePasswordScenario _changePasswordScenario;
    private readonly AdminLogoutScenario _adminLogoutScenario;

    public AdminChoiceScenario(
        AddUserScenario addUserScenario,
        ChangePasswordScenario changePasswordScenario,
        AdminLogoutScenario adminLogoutScenario)
    {
        _addUserScenario = addUserScenario;
        _changePasswordScenario = changePasswordScenario;
        _adminLogoutScenario = adminLogoutScenario;
    }

    public string Name => "Admin Options";

    public void Run()
    {
        string scenario = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices(new[] { "Add User", "Change Password", "Logout" }));

        switch (scenario)
        {
            case "Add User":
                _addUserScenario.Run();
                break;
            case "Change Password":
                _changePasswordScenario.Run();
                break;
            case "Logout":
                _adminLogoutScenario.Run();
                break;
            default:
                AnsiConsole.MarkupLine("[red]Invalid option selected[/]");
                break;
        }
    }
}