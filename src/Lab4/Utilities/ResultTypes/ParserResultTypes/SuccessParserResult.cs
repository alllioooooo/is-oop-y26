using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Utilities.ResultTypes.ParserResultTypes;

public record SuccessParserResult(ICommand Result) : ParserResultType
{
    public override bool Success => true;
    public new ICommand? Result { get; } = Result;
}