using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FlagParsers;

public class AcceptableModesForFileShowCommand
{
    public IReadOnlyCollection<string> Modes { get; } = new ReadOnlyCollection<string>(new List<string>() { "console" });
}