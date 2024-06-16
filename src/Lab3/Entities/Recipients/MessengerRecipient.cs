using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class MessengerRecipient : IRecipient
{
    private readonly IMessenger _messenger;

    public MessengerRecipient(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void Receive(Message message)
    {
        string formattedMessage = FormatMessageForMessenger(message);
        _messenger.Receive(formattedMessage);
    }

    private static string FormatMessageForMessenger(Message message)
    {
        return $"Title: {message.Title}, Body: {message.Body}";
    }
}