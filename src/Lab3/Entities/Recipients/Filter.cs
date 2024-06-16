using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients;

public class Filter : IRecipient
{
    private readonly IRecipient _nextRecipient;
    private readonly HashSet<MessagePriority> _acceptedPriorities;
    private readonly Resulting _resulting;

    public Filter(IRecipient nextRecipient, IEnumerable<MessagePriority> acceptedPriorities, Resulting resulting)
    {
        _nextRecipient = nextRecipient;
        _acceptedPriorities = new HashSet<MessagePriority>(acceptedPriorities);
        _resulting = resulting;
    }

    public void Receive(Message message)
    {
        Result result;
        if (_acceptedPriorities.Contains(message.Priority))
        {
            _nextRecipient.Receive(message);
            result = new SuccessResult($"Message '{message.Title}' passed the filter and was sent.");
        }
        else
        {
            result = new FailureResult($"Message '{message.Title}' with priority '{message.Priority}' did not pass the filter criteria.");
        }

        _resulting.AddResult(result);
    }
}
