using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class ConsoleMessenger : IMessenger
{
    public void WriteMessage(string message)
    {
        Console.WriteLine($"Messenger: {message}");
    }

    public void Receive(string message)
    {
        WriteMessage(message);
    }
}