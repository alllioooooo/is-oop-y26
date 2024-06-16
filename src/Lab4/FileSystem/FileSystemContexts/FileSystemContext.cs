using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Displays;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.CommandsResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;

public class FileSystemContext
{
    public string? ConnectionPath { get; private set; }
    public string? CurrentPath { get; private set; }
    public string? Mode { get; private set; }
    public IFileSystemManager? FileSystemManager { get; private set; }

    public CommandsResultType Connect(string? address, string? mode)
    {
        if (!Directory.Exists(address))
        {
            return new FailureCommandsResult($"The specified path does not exist or cannot be reached: {address}.");
        }

        ConnectionPath = address;
        CurrentPath = address;
        Mode = mode;
        FileSystemManager = new MacOSFileSystemManager(ConnectionPath, CurrentPath);
        IConsoleDisplay consoleDisplay = new ConsoleDisplay();
        CommandsResultType result = new SuccessCommandsResult($"Connected to {address} in mode {mode}.");
        consoleDisplay.ShowText(result.Message);
        return result;
    }

    public CommandsResultType Disconnect()
    {
        ConnectionPath = string.Empty;
        CurrentPath = string.Empty;
        Mode = string.Empty;
        IConsoleDisplay consoleDisplay = new ConsoleDisplay();
        CommandsResultType result = new SuccessCommandsResult("Disconnected from file system.");
        consoleDisplay.ShowText(result.Message);
        return result;
    }
}
