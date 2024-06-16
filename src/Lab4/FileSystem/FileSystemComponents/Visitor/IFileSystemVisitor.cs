namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemComponents.Visitor;

public interface IFileSystemVisitor
{
    void VisitFile(FileComponent file);
    void VisitDirectory(DirectoryComponent dir);
}