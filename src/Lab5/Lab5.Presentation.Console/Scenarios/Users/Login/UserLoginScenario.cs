using Lab5.Domain.Contracts.Users;
using Lab5.Presentation.Console.Scenarios.Users.UserChoice;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Users.Login;

public class UserLoginScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly UserChoiceScenario _userChoiceScenario;

    public UserLoginScenario(IUserService userService, UserChoiceScenario userChoiceScenario)
    {
        _userService = userService;
        _userChoiceScenario = userChoiceScenario;
    }

    public string Name => "User Login";

    public async void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username:");

        UserLoginResult result = await _userService.LoginAsync(username);

        switch (result)
        {
            case UserLoginResult.Success:
                AnsiConsole.MarkupLine("[green]Login successful![/]");
                break;
            case UserLoginResult.NotFound:
                AnsiConsole.MarkupLine("[red]Admin not found![/]");
                break;
        }

        AnsiConsole.MarkupLine("[yellow]Press any key to continue...[/]");
        System.Console.ReadKey(true);

        if (result is UserLoginResult.Success)
        {
            _userChoiceScenario.Run();
        }
    }
}