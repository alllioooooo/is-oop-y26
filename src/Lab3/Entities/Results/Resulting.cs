using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Results;

public record Resulting
{
    public IList<Result> Results { get;  } = new List<Result>();

    public void AddResult(Result result)
    {
        Results.Add(result);
    }
}