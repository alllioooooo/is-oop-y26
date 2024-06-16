using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidationModel;

public interface IPCValidator
{
    public IReadOnlyList<CompatibilityResult?> ValidateComponents();
}