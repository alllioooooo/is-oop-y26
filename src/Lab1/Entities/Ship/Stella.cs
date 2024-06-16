using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Stella : IShip
{
    public Stella(IDeflector? deflector = null)
    {
        Deflector = deflector ?? new DeflectorClass1();
    }

    public IImpulseEngine ImpulseEngine { get; } = new CClassEngine();
    public IJumpEngine JumpEngine { get; } = new OmegaJumpEngine();
    public IDeflector? Deflector { get; }
    public AntiNitreneEmitter? AntiNitreneEmitter { get; }
    public IHullStrength HullStrength { get; } = new HullStrengthClass1();
}