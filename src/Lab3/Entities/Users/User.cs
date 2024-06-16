using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User
{
    private readonly List<MessageRecord> _messages = new List<MessageRecord>();
    private readonly HashSet<MessagePriority> _acceptedPriorities;

    public User(string name, IEnumerable<MessagePriority> acceptedPriorities)
    {
        Name = name;
        _acceptedPriorities = new HashSet<MessagePriority>(acceptedPriorities);
    }

    public string Name { get; }

    public void ReceiveMessage(Message message)
    {
        _messages.Add(new MessageRecord(message, MessageStatus.Unread));
    }

    public Result MarkMessageAsRead(Message message)
    {
        MessageRecord? messageRecord = _messages.FirstOrDefault(mr => mr.Message == message);
        if (messageRecord is { Status: MessageStatus.Unread })
        {
            _messages.Remove(messageRecord);
            _messages.Add(messageRecord with { Status = MessageStatus.Read });
            return new SuccessResult($"Message '{message.Title}' marked as read by {Name}.");
        }
        else
        {
            return new FailureResult($"User {Name} cannot mark message: '{message.Title}' as read. It may already be read or does not exist.");
        }
    }

    public IReadOnlyList<MessageRecord> GetAllMessages()
    {
        return _messages.AsReadOnly();
    }

    public void SetAcceptedPriorities(IEnumerable<MessagePriority> priorities)
    {
        _acceptedPriorities.Clear();
        foreach (MessagePriority priority in priorities)
        {
            _acceptedPriorities.Add(priority);
        }
    }
}