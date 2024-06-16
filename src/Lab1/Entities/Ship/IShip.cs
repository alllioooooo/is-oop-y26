using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public interface IShip
{
    IHullStrength HullStrength { get; }
    IImpulseEngine ImpulseEngine { get; }
    IJumpEngine? JumpEngine { get; }
    IDeflector? Deflector { get; }
    AntiNitreneEmitter? AntiNitreneEmitter { get; }
}