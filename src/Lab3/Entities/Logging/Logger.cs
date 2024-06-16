using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Logging;

public class Logger : ILogger
{
    private readonly List<LogEntry> _logEntries = new();

    public void Log(string message)
    {
        var logEntry = new LogEntry(message);
        _logEntries.Add(logEntry);
    }

    public IEnumerable<LogEntry> GetLogEntries() => _logEntries.AsReadOnly();
}