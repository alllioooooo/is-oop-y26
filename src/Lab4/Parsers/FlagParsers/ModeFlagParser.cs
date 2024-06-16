using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FlagParsers;

public class ModeFlagParser : IFlagParser
{
    public string? Parse(string?[] args)
    {
        int index = Array.IndexOf(args, "-m");
        if (index != -1 && index < args.Length - 1)
        {
            return args[index + 1];
        }

        return string.Empty;
    }
}