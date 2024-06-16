using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

public interface ICommandParser
{
    ParserResultType? Parse(string?[] args);
}