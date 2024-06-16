using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

public class FileDeleteCommandParser : ICommandParser
{
    private FileSystemContext _context;

    public FileDeleteCommandParser(FileSystemContext context)
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
            !secondPart.Equals("delete", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect second part.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string path) ||
            string.IsNullOrWhiteSpace(path))
            return new FailureParserResult("FileDeleteCommand requires a path.");

        if (argEnumerator.MoveNext())
            return new FailureParserResult("FileCopyCommand expects exactly 1 argument for path.");

        var fileDeleteCommand = new FileDeleteCommand(_context, path);
        return new SuccessParserResult(fileDeleteCommand);
    }
}