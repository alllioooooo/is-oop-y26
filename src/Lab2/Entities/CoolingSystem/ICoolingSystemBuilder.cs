using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public interface ICoolingSystemBuilder
{
    ICoolingSystemBuilder SetDimensions(string dimensions);
    ICoolingSystemBuilder SetSupportedSockets(IReadOnlyList<string> supportedSockets);
    ICoolingSystemBuilder SetMaxTDP(int maxTDP);
    CoolingSystem Build();
}