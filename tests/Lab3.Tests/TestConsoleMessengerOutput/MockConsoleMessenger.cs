using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.TestConsoleMessengerOutput;

public class MockConsoleMessenger : IMessenger
{
    public string? LastMessage { get; private set; }

    public void WriteMessage(string message)
    {
        LastMessage = $"Messenger: {message}";
    }

    public void Receive(string message)
    {
        WriteMessage(message);
    }
}
