using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private FileSystemContext _context;
    public FileRenameCommand(FileSystemContext context, string path, string newName)
    {
        _context = context;
        Path = path;
        NewName = newName;
    }

    public string Path { get; }
    public string NewName { get; }

    public void Execute()
    {
        _context.FileSystemManager?.RenameFile(Path, NewName);
    }
}