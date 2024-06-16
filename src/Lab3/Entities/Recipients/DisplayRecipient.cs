using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger.Display;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class DisplayRecipient : IRecipient
{
    private readonly IDisplay _display;

    public DisplayRecipient(IDisplay display)
    {
        _display = display;
    }

    public void Receive(Message message)
    {
        string formattedMessage = FormatMessageForDisplay(message);
        _display.Receive(formattedMessage);
    }

    private static string FormatMessageForDisplay(Message message)
    {
        return $"Title: {message.Title}, Body: {message.Body}";
    }
}