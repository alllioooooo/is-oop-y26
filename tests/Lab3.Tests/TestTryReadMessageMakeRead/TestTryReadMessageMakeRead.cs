using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.TestTryReadMessageMakeRead;

public class TestTryReadMessageMakeRead
{
    private readonly User _user;
    private readonly Message _message;

    public TestTryReadMessageMakeRead()
    {
        _user = new User("TestUser", new[] { MessagePriority.Normal });
        _message = new Message("TestTitle", "TestBody", MessagePriority.Normal);

        var resulting = new Resulting();
        var userRecipient = new UserRecipient(_user.Name, new[] { MessagePriority.Normal });
        var filter = new Filter(userRecipient, new HashSet<MessagePriority> { MessagePriority.Normal }, resulting);
        var topic = new Topic(_message.Title, filter);

        topic.SendMessage(_message);

        _user.MarkMessageAsRead(_message);
    }

    [Fact]
    public void MarkMessageAsRead_GeneratesFailureResult_WhenMessageIsAlreadyRead()
    {
        Result result = _user.MarkMessageAsRead(_message);

        Assert.IsType<FailureResult>(result);
        Assert.Contains("cannot mark message", result.Message, StringComparison.Ordinal);
    }
}