using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private FileSystemContext _context;

    public TreeListCommand(FileSystemContext context, int depth)
    {
        _context = context;
        Depth = depth;
    }

    public int Depth { get; }

    public void Execute()
    {
        _context.FileSystemManager?.ListDirectory(_context.CurrentPath, Depth);
    }
}