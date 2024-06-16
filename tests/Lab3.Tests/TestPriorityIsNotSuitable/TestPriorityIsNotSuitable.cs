using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.TestPriorityIsNotSuitable;

public class TestPriorityIsNotSuitable
{
    [Fact]
    public void MessageWithUnsuitablePriority_IsNotReceivedByRecipient()
    {
        IRecipient? recipient = Substitute.For<IRecipient>();

        var resulting = new Resulting();

        var filter = new Filter(recipient, new HashSet<MessagePriority> { MessagePriority.High }, resulting);

        var message = new Message("Title", "Body", MessagePriority.Normal);

        var topic = new Topic(message.Title, filter);

        topic.SendMessage(message);

        recipient.DidNotReceive().Receive(message);

        Assert.Single(resulting.Results);
        Assert.IsType<FailureResult>(resulting.Results[0]);
    }
}