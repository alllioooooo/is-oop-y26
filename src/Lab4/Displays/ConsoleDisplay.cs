using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Displays;

public class ConsoleDisplay : IConsoleDisplay
{
    public void ShowText(string text)
    {
        Console.WriteLine(text);
    }
}