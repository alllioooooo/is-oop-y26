using System;
using System.Collections;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FlagParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

public class ConnectionCommandParser : ICommandParser
{
    private readonly AcceptableModesForConnectionCommand _acceptableModes = new AcceptableModesForConnectionCommand();

    private FileSystemContext _context;

    public ConnectionCommandParser(FileSystemContext context)
    {
        _context = context;
    }

    private string? DefaultMode { get; } = "local";

    public ParserResultType? Parse(string?[] args)
    {
        IEnumerator argEnumerator = args.GetEnumerator();
        argEnumerator.MoveNext();

        string? currentCommand = argEnumerator.Current as string;
        if (currentCommand == null || !currentCommand.Equals("connect", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or invalid arguments.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string address) || string.IsNullOrWhiteSpace(address))
            return new FailureParserResult("No address provided for ConnectCommand.");

        var modeFlagParser = new ModeFlagParser();
        string? mode = modeFlagParser.Parse(args);
        if (string.IsNullOrWhiteSpace(mode))
        {
            mode = DefaultMode;
        }

        if (!_acceptableModes.Modes.Contains(mode))
        {
            return new FailureParserResult($"Invalid mode '{mode}'. Supported modes: {string.Join(", ", _acceptableModes.Modes)}.");
        }

        var connectCommand = new ConnectCommand(_context, address, mode);
        return new SuccessParserResult(connectCommand);
    }
}