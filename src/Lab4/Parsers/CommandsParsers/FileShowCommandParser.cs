using System;
using System.Collections;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FlagParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

public class FileShowCommandParser : ICommandParser
{
    private readonly AcceptableModesForFileShowCommand _acceptableModes = new AcceptableModesForFileShowCommand();

    private FileSystemContext _context;

    public FileShowCommandParser(FileSystemContext context)
    {
        _context = context;
    }

    private string? DefaultMode { get; } = "console";

    public ParserResultType? Parse(string?[] args)
    {
        IEnumerator argEnumerator = args.GetEnumerator();

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string firstPart) ||
            !firstPart.Equals("file", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect first part.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string secondPart) ||
            !secondPart.Equals("show", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect second part.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string path) ||
            string.IsNullOrWhiteSpace(path))
            return new FailureParserResult("FileShowCommand requires a path.");

        var modeFlagParser = new ModeFlagParser();
        string? mode = modeFlagParser.Parse(args);
        if (string.IsNullOrWhiteSpace(mode))
        {
            mode = DefaultMode;
        }

        if (!_acceptableModes.Modes.Contains(mode))
        {
            return new FailureParserResult($"Invalid mode for FileShowCommand. Supported modes: {string.Join(", ", _acceptableModes.Modes)}. Received mode: {mode}");
        }

        var fileShowCommand = new FileShowCommand(_context, path, mode);
        return new SuccessParserResult(fileShowCommand);
    }
}