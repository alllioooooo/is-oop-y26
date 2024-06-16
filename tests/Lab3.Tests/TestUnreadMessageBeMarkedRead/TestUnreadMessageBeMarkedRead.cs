using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.TestUnreadMessageBeMarkedRead;

public class TestUnreadMessageBeMarkedRead
{
    private readonly User _user;
    private readonly Message _message;

    public TestUnreadMessageBeMarkedRead()
    {
        _user = new User("TestUser", new[] { MessagePriority.Normal });
        _message = new Message("TestTitle", "TestBody", MessagePriority.Normal);

        var resulting = new Resulting();
        var userRecipient = new UserRecipient(_user.Name, new[] { MessagePriority.Normal });
        var filter = new Filter(userRecipient, new HashSet<MessagePriority> { MessagePriority.Normal }, resulting);
        var topic = new Topic(_message.Title, filter);

        topic.SendMessage(_message);
    }

    [Fact]
    public void MarkMessageAsRead_ChangesStatusToRead_WhenMessageIsUnread()
    {
        _user.MarkMessageAsRead(_message);

        Assert.True(_user.GetAllMessages().All(m => m.Status == MessageStatus.Read));
    }
}