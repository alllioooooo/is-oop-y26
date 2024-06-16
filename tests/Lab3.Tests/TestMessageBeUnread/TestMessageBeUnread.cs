using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.TestMessageBeUnread;

public class TestMessageBeUnread
{
    private readonly User _user = new("TestUser", new[] { MessagePriority.Normal });
    private readonly Message _message = new("TestTitle", "TestBody", MessagePriority.Normal);

    [Fact]
    public void ReceiveMessage_MessageSavedAsUnread_WhenReceived()
    {
        var resulting = new Resulting();
        var userRecipient = new UserRecipient(_user.Name, new[] { MessagePriority.Normal });
        var filter = new Filter(userRecipient, new HashSet<MessagePriority> { MessagePriority.Normal }, resulting);
        var topic = new Topic(_message.Title, filter);

        topic.SendMessage(_message);

        Assert.True(_user.GetAllMessages().All(m => m.Status == MessageStatus.Unread));
    }
}