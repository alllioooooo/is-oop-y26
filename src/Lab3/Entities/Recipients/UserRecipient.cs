using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class UserRecipient : User, IRecipient
{
    public UserRecipient(string name, IEnumerable<MessagePriority> acceptedPriorities)
        : base(name, acceptedPriorities)
    {
    }

    public void Receive(Message message)
    {
        ReceiveMessage(message);
    }
}