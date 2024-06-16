using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private FileSystemContext _context;
    public ConnectCommand(FileSystemContext context, string? address, string? mode = "local")
    {
        _context = context;
        Address = address;
        Mode = mode;
    }

    public string? Address { get; }
    public string? Mode { get; }

    public void Execute()
    {
        _context.Connect(Address, Mode);
    }
}