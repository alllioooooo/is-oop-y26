using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public interface IBIOSBuilder
{
    IBIOSBuilder SetType(string type);
    IBIOSBuilder SetVersion(string version);
    IBIOSBuilder SetSupportedProcessors(IReadOnlyList<string> supportedProcessors);
    BIOS Build();
}