using System;
using System.Collections;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FlagParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

public class TreeListCommandParser : ICommandParser
{
    private FileSystemContext _context;

    public TreeListCommandParser(FileSystemContext context)
    {
        _context = context;
    }

    private string DefaultDepth { get; } = "2";

    public ParserResultType? Parse(string?[] args)
    {
        IEnumerator argEnumerator = args.GetEnumerator();

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string firstPart) ||
            !firstPart.Equals("tree", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect first part.");

        if (!argEnumerator.MoveNext() || !(argEnumerator.Current is string secondPart) ||
            !secondPart.Equals("list", StringComparison.Ordinal))
            return new FailureParserResult("Unknown command or incorrect second part.");

        var depthFlagParser = new DepthFlagParser();
        string? depthStr = depthFlagParser.Parse(args);

        int depth = string.IsNullOrWhiteSpace(depthStr)
            ? int.Parse(DefaultDepth, CultureInfo.InvariantCulture)
            : int.Parse(depthStr, CultureInfo.InvariantCulture);

        if (depth < 0)
            return new FailureParserResult("Depth must be a positive integer.");

        var treeListCommand = new TreeListCommand(_context, depth);
        return new SuccessParserResult(treeListCommand);
    }
}