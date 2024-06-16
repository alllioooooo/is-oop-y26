namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger.Display;

public class ConsoleDisplay : IDisplay
{
    private readonly IDisplayDriver _driver;

    public ConsoleDisplay(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void ShowMessage(string message)
    {
        _driver.Clear();
        _driver.WriteText(message);
    }

    public void Receive(string message)
    {
        ShowMessage(message);
    }
}