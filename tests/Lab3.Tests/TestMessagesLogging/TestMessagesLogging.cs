using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.TestMessagesLogging;

public class TestMessagesLogging
{
    [Fact]
    public void MessageReceived_LogsMessage()
    {
        IRecipient innerRecipient = Substitute.For<IRecipient>();
        ILogger logger = Substitute.For<ILogger>();

        var resulting = new Resulting();

        var message = new Message("TestTitle", "TestBody", MessagePriority.Normal);
        var filter = new Filter(innerRecipient, new HashSet<MessagePriority> { MessagePriority.Normal }, resulting);
        var loggingRecipient = new LoggingRecipientDecorator(filter, logger);

        var topic = new Topic(message.Title, loggingRecipient);

        topic.SendMessage(message);

        logger.Received(1)
            .Log(Arg.Is<string>(logMessage => logMessage.Contains("TestTitle") && logMessage.Contains("Normal")));

        innerRecipient.Received(1).Receive(message);
    }
}