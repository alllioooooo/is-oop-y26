using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private FileSystemContext _context;
    public FileDeleteCommand(FileSystemContext context, string path)
    {
        _context = context;
        Path = path;
    }

    public string Path { get; }

    public void Execute()
    {
        _context.FileSystemManager?.DeleteFile(Path);
    }
}