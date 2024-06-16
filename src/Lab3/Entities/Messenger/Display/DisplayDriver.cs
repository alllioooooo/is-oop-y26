using System;
using Crayon;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger.Display;

public class DisplayDriver : IDisplayDriver
{
    private string _currentColor = "blue";

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(string color)
    {
        _currentColor = color;
    }

    public void WriteText(string text)
    {
        string coloredText = GetColoredText(text, _currentColor);
        Console.WriteLine(coloredText);
    }

    private static string GetColoredText(string text, string color)
    {
        return color.ToLower(System.Globalization.CultureInfo.CurrentCulture) switch
        {
            "red" => Output.Red(text),
            "green" => Output.Green(text),
            "blue" => Output.Blue(text),
            _ => text,
        };
    }
}