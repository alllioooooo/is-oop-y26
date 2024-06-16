using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGotoCommand : ICommand
{
    private FileSystemContext _context;
    public TreeGotoCommand(FileSystemContext context, string path)
    {
        _context = context;
        Path = path;
    }

    public string Path { get; }

    public void Execute()
    {
        _context.FileSystemManager?.TreeGoto(Path);
    }
}