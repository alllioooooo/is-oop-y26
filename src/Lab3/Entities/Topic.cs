using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    private readonly IRecipient _addressee;

    public Topic(string title, IRecipient addressee)
    {
        Title = title;
        _addressee = addressee;
    }

    public string Title { get; }

    public void SendMessage(Message message)
    {
        _addressee.Receive(message);
    }
}