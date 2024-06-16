using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Displays;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Trees;
using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.CommandsResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class MacOSFileSystemManager : IFileSystemManager
{
    private readonly string _connectionPath;
    private string _currentPath;
    private IConsoleDisplay _display = new ConsoleDisplay();

    public MacOSFileSystemManager(string connectionPath, string currentPath)
    {
        _connectionPath = connectionPath;
        _currentPath = currentPath;
    }

    public CommandsResultType ListDirectory(string? path, int depth)
    {
        if (path != null)
        {
            string fullPath = Path.GetFullPath(Path.Combine(_currentPath, path));
            DirectoryComponent? dirComponent = FindDirectoryComponent(fullPath);

            if (dirComponent == null)
            {
                return new FailureCommandsResult($"Directory not found at path {path}.");
            }

            var listingVisitor = new ListingVisitor(depth);
            var folderTree = new FolderTree(dirComponent);
            folderTree.Accept(listingVisitor);

            _display.ShowText(string.Join("\n", listingVisitor.ListedEntries));
        }

        return new SuccessCommandsResult("Directory listed successfully.");
    }

    public CommandsResultType ShowFile(string path)
    {
        string fullPath = Path.Combine(_currentPath, path);
        if (File.Exists(fullPath))
        {
            string content = File.ReadAllText(fullPath);
            CommandsResultType result = new SuccessCommandsResult(content);
            _display.ShowText(result.Message);
            return result;
        }

        return new FailureCommandsResult($"File not found at path {path}.");
    }

    public CommandsResultType MoveFile(string sourcePath, string destinationPath)
    {
        string fullPathSource = Path.Combine(_currentPath, sourcePath);
        string fullPathDestination = Path.Combine(_currentPath, destinationPath);

        if (!File.Exists(fullPathSource))
        {
            return new FailureCommandsResult($"Source file not found at path {sourcePath}.");
        }

        File.Copy(fullPathSource, fullPathDestination, overwrite: true);
        File.Delete(fullPathSource);

        CommandsResultType result = new SuccessCommandsResult($"File moved from {sourcePath} to {destinationPath}.");
        _display.ShowText(result.Message);
        return result;
    }

    public CommandsResultType CopyFile(string sourcePath, string destinationPath)
    {
        string fullPathSource = Path.Combine(_currentPath, sourcePath);
        string fullPathDestination = Path.Combine(_currentPath, destinationPath);

        if (!File.Exists(fullPathSource))
        {
            return new FailureCommandsResult($"Source file not found at path {sourcePath}.");
        }

        File.Copy(fullPathSource, fullPathDestination, overwrite: false);

        CommandsResultType result = new SuccessCommandsResult($"File copied from {sourcePath} to {destinationPath}.");
        _display.ShowText(result.Message);
        return result;
    }

    public CommandsResultType DeleteFile(string path)
    {
        string fullPath = Path.Combine(_currentPath, path);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);

            CommandsResultType result = new SuccessCommandsResult($"File {path} was deleted.");
            _display.ShowText(result.Message);
            return result;
        }

        return new FailureCommandsResult($"File not found at path {path}.");
    }

    public CommandsResultType RenameFile(string path, string newName)
    {
        string fullPath = Path.Combine(_currentPath, path);
        if (!File.Exists(fullPath))
        {
            return new FailureCommandsResult($"File not found at path {path}.");
        }

        string newPath = Path.Combine(_currentPath, newName);
        File.Move(fullPath, newPath);

        CommandsResultType result = new SuccessCommandsResult($"File {path} was renamed to {newName}.");
        _display.ShowText(result.Message);
        return result;
    }

    public CommandsResultType TreeGoto(string path)
    {
        string? fullPath = Path.Combine(_connectionPath, path);
        if (Directory.Exists(fullPath) || File.Exists(fullPath))
        {
            _currentPath = fullPath;

            CommandsResultType result = new SuccessCommandsResult($"Current path changed to {_currentPath}.");
            _display.ShowText(result.Message);
            return result;
        }

        return new FailureCommandsResult($"Path not found: {path}.");
    }

    private DirectoryComponent? FindDirectoryComponent(string fullPath)
    {
        var currentDirectory = new DirectoryInfo(_currentPath);

        return FindDirectoryComponentRecursive(currentDirectory, fullPath);
    }

    private DirectoryComponent? FindDirectoryComponentRecursive(DirectoryInfo currentDirectoryInfo, string fullPath)
    {
        if (Path.GetFullPath(currentDirectoryInfo.FullName) == fullPath)
        {
            return new DirectoryComponent(currentDirectoryInfo.Name);
        }

        foreach (DirectoryInfo directoryInfo in currentDirectoryInfo.GetDirectories())
        {
            DirectoryComponent? result = FindDirectoryComponentRecursive(directoryInfo, fullPath);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}