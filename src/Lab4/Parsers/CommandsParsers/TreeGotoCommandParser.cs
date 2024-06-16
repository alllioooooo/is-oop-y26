using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

public class TreeGotoCommandParser : ICommandParser
{
    private FileSystemContext _context;

    public TreeGotoCommandParser(FileSystemContext context)
    {
        _context = context;
    }

    public ParserResultType? Parse(string?[] args)
    {
        IEnumerator argEnumerator = args.GetEnumerator();

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string firstPart) ||
            !firstPart.Equals("tree", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect first part.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string secondPart) ||
            !secondPart.Equals("goto", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect second part.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string path) ||
            string.IsNullOrWhiteSpace(path))
            return new FailureParserResult("TreeGotoCommand requires a path.");

        if (argEnumerator.MoveNext())
            return new FailureParserResult("TreeGotoCommand expects exactly 1 argument for path.");

        var treeGotoCommand = new TreeGotoCommand(_context, path);
        return new SuccessParserResult(treeGotoCommand);
    }
}