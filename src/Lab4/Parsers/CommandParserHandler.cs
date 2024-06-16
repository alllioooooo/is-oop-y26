using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class CommandParserHandler
{
    private ICommandParser _parser;
    private CommandParserHandler? _nextHandler;

    public CommandParserHandler(ICommandParser parser)
    {
        _parser = parser;
    }

    public CommandParserHandler SetNext(CommandParserHandler nextHandler)
    {
        _nextHandler = nextHandler;
        return nextHandler;
    }

    public ICommand? Parse(string?[] args)
    {
        ParserResultType? result = _parser.Parse(args);
        if (result is SuccessParserResult successResult)
        {
            return successResult.Result;
        }

        if (_nextHandler != null)
        {
            return _nextHandler.Parse(args);
        }
        else
        {
            return null;
        }
    }
}