using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents;

public class FileComponent : IFileSystemComponent
{
    public FileComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.VisitFile(this);
    }
}