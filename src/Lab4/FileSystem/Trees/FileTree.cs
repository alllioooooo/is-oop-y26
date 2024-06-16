using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Trees;

public class FileTree : ITree
{
    private FileComponent _fileComponent;

    public FileTree(FileComponent fileComponent)
    {
        _fileComponent = fileComponent;
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        _fileComponent.Accept(visitor);
    }
}