using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents;

public interface IFileSystemComponent
{
    void Accept(IFileSystemVisitor visitor);
}