using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private FileSystemContext _context;
    public FileMoveCommand(FileSystemContext context, string sourcePath, string destinationPath)
    {
        _context = context;
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string SourcePath { get; }
    public string DestinationPath { get; }

    public void Execute()
    {
        _context.FileSystemManager?.MoveFile(SourcePath, DestinationPath);
    }
}