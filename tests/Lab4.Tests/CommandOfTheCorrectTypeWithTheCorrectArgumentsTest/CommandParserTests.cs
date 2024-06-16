using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.CommandOfTheCorrectTypeWithTheCorrectArgumentsTest;

public class CommandParserTests
{
    private readonly FileSystemContext _context = new FileSystemContext();

    [Theory]
    [InlineData("connect address -m local", typeof(ConnectCommand))]
    [InlineData("disconnect", typeof(DisconnectCommand))]
    [InlineData("file copy sourcePath destinationPath", typeof(FileCopyCommand))]
    [InlineData("file delete filePath", typeof(FileDeleteCommand))]
    [InlineData("file move sourcePath destinationPath", typeof(FileMoveCommand))]
    [InlineData("file rename filePath newName", typeof(FileRenameCommand))]
    [InlineData("file show filePath", typeof(FileShowCommand))]
    [InlineData("tree goto path", typeof(TreeGotoCommand))]
    [InlineData("tree list -d 2", typeof(TreeListCommand))]
    public void CommandParser_ShouldReturnCorrectCommandType(string input, System.Type expectedCommandType)
    {
        var parser = new CommandParser(_context);

        ICommand? command = parser.Parse(input);

        Assert.IsType(expectedCommandType, command);
    }
}