using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    private FileSystemContext _context;
    public DisconnectCommand(FileSystemContext context)
    {
        _context = context;
    }

    public void Execute()
    {
        _context.Disconnect();
    }
}
