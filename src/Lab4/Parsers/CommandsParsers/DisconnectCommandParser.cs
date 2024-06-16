using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

public class DisconnectCommandParser : ICommandParser
{
    private FileSystemContext _context;

    public DisconnectCommandParser(FileSystemContext context)
    {
        _context = context;
    }

    public ParserResultType? Parse(string?[] args)
    {
        IEnumerator argEnumerator = args.GetEnumerator();
        argEnumerator.MoveNext();

        string? currentCommand = argEnumerator.Current as string;
        if (currentCommand == null || !currentCommand.Equals("disconnect", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command.");

        if (argEnumerator.MoveNext())
            return new FailureParserResult("Disconnect command does not expect any arguments.");

        var disconnectCommand = new DisconnectCommand(_context);
        return new SuccessParserResult(disconnectCommand);
    }
}