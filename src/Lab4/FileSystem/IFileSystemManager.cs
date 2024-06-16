using Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.CommandsResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystemManager
{
    CommandsResultType ListDirectory(string? path, int depth);
    CommandsResultType ShowFile(string path);
    CommandsResultType MoveFile(string sourcePath, string destinationPath);
    CommandsResultType CopyFile(string sourcePath, string destinationPath);
    CommandsResultType DeleteFile(string path);
    CommandsResultType RenameFile(string path, string newName);
    public CommandsResultType TreeGoto(string path);
}