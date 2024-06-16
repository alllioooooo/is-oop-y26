using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Trees;

public class FolderTree : ITree
{
    private DirectoryComponent _directoryComponent;

    public FolderTree(DirectoryComponent directoryComponent)
    {
        _directoryComponent = directoryComponent;
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        _directoryComponent.Accept(visitor);
    }
}