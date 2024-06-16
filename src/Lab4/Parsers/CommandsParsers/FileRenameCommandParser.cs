using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

public class FileRenameCommandParser : ICommandParser
{
    private FileSystemContext _context;

    public FileRenameCommandParser(FileSystemContext context)
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
            !secondPart.Equals("rename", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect second part.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string path) ||
            string.IsNullOrWhiteSpace(path))
            return new FailureParserResult("FileRenameCommand requires a path.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string newName) ||
            string.IsNullOrWhiteSpace(newName))
            return new FailureParserResult("FileRenameCommand requires a new name.");

        if (argEnumerator.MoveNext())
            return new FailureParserResult("FileRenameCommand expects exactly 2 arguments for path and new name.");

        var fileRenameCommand = new FileRenameCommand(_context, path, newName);
        return new SuccessParserResult(fileRenameCommand);
    }
}