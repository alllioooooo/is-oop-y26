using Itmo.ObjectOrientedProgramming.Lab3.Entities.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class LoggingRecipientDecorator : IRecipient
{
    private readonly IRecipient _innerRecipient;
    private readonly ILogger _logger;

    public LoggingRecipientDecorator(IRecipient innerRecipient, ILogger logger)
    {
        _innerRecipient = innerRecipient;
        _logger = logger;
    }

    public void Receive(Message message)
    {
        _logger.Log($"LoggingRecipientDecorator: Message '{message.Title}' received with priority {message.Priority}.");
        _innerRecipient.Receive(message);
    }
}