using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.CommandsParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class CommandParser
{
    private readonly CommandParserHandler _chain;
    private FileSystemContext _context;

    public CommandParser(FileSystemContext context)
    {
        _context = context;
        var connectionParser = new CommandParserHandler(new ConnectionCommandParser(_context));
        var disconnectParser = new CommandParserHandler(new DisconnectCommandParser(_context));
        var fileCopyParser = new CommandParserHandler(new FileCopyCommandParser(_context));
        var fileDeleteParser = new CommandParserHandler(new FileDeleteCommandParser(_context));
        var fileMoveParser = new CommandParserHandler(new FileMoveCommandParser(_context));
        var fileRenameParser = new CommandParserHandler(new FileRenameCommandParser(_context));
        var fileShowParser = new CommandParserHandler(new FileShowCommandParser(_context));
        var treeGotoParser = new CommandParserHandler(new TreeGotoCommandParser(_context));
        var treeListParser = new CommandParserHandler(new TreeListCommandParser(_context));

        connectionParser
            .SetNext(disconnectParser)
            .SetNext(fileCopyParser)
            .SetNext(fileDeleteParser)
            .SetNext(fileMoveParser)
            .SetNext(fileRenameParser)
            .SetNext(fileShowParser)
            .SetNext(treeGotoParser)
            .SetNext(treeListParser);

        _chain = connectionParser;
    }

    public ICommand? Parse(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        string[] args = input.Split(' ');
        return _chain.Parse(args);
    }
}
