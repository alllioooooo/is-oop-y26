using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

public class FileMoveCommandParser : ICommandParser
{
    private FileSystemContext _context;

    public FileMoveCommandParser(FileSystemContext context)
    {
        _context = context;
    }

    public ParserResultType? Parse(string?[] args)
    {
        IEnumerator argEnumerator = args.GetEnumerator();

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string firstPart) ||
            !firstPart.Equals("file", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect first part.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string secondPart) ||
            !secondPart.Equals("move", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect second part.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string sourcePath) ||
            string.IsNullOrWhiteSpace(sourcePath))
            return new FailureParserResult("FileMoveCommand requires a source path.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string destinationPath) ||
            string.IsNullOrWhiteSpace(destinationPath))
            return new FailureParserResult("FileMoveCommand requires a destination path.");

        if (argEnumerator.MoveNext())
            return new FailureParserResult("FileMoveCommand expects exactly 2 arguments for paths.");

        var fileMoveCommand = new FileMoveCommand(_context, sourcePath, destinationPath);
        return new SuccessParserResult(fileMoveCommand);
    }
}