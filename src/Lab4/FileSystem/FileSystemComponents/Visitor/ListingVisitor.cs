using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents.Visitor;

public class ListingVisitor : IFileSystemVisitor
{
    private readonly IList<string> _listedEntries = new List<string>();
    private int _currentDepth;

    public ListingVisitor(int maxDepth)
    {
        MaxDepth = maxDepth;
    }

    public int MaxDepth { get; }

    public IEnumerable<string> ListedEntries => _listedEntries.AsReadOnly();

    public void VisitFile(FileComponent file)
    {
        if (_currentDepth <= MaxDepth)
        {
            _listedEntries.Add($"{new string(' ', _currentDepth * 2)}{file.Name}");
        }
    }

    public void VisitDirectory(DirectoryComponent dir)
    {
        if (_currentDepth <= MaxDepth)
        {
            _currentDepth++;
            _listedEntries.Add($"{new string(' ', _currentDepth * 2)}{dir.Name}/");
            _currentDepth--;
        }
    }
}