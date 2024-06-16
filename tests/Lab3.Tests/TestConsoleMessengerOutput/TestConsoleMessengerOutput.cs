using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.TestConsoleMessengerOutput;

public class TestConsoleMessengerOutput
{
    [Fact]
    public void SendMessage_OutputContainsMessenger()
    {
        var mockMessenger = new MockConsoleMessenger();
        var messengerRecipient = new MessengerRecipient(mockMessenger);

        var resulting = new Resulting();
        var filter = new Filter(messengerRecipient, new HashSet<MessagePriority> { MessagePriority.Normal }, resulting);
        var topic = new Topic("TestTitle", filter);

        var message = new Message("TestTitle", "TestBody", MessagePriority.Normal);

        topic.SendMessage(message);

        Assert.Equal($"Messenger: Title: {message.Title}, Body: {message.Body}", mockMessenger.LastMessage);
    }
}