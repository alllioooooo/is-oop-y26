using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents;

public class DirectoryComponent : IFileSystemComponent
{
    private IList<IFileSystemComponent> _children = new List<IFileSystemComponent>();

    public DirectoryComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public IEnumerable? Children { get; }

    public void AddChild(IFileSystemComponent component)
    {
        _children.Add(component);
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.VisitDirectory(this);
        foreach (IFileSystemComponent child in _children)
        {
            child.Accept(visitor);
        }
    }
}