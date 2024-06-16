using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private FileSystemContext _context;
    public FileShowCommand(FileSystemContext context, string path, string? mode)
    {
        _context = context;
        Path = path;
        Mode = mode;
    }

    public string Path { get; }
    public string? Mode { get; }

    public void Execute()
    {
        _context.FileSystemManager?.ShowFile(Path);
    }
}
