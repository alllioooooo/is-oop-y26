namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message
{
    public Message(string title, string body, MessagePriority priority)
    {
        Title = title;
        Body = body;
        Priority = priority;
    }

    public string Title { get; }

    public string Body { get; }

    public MessagePriority Priority { get; }
}