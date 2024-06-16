using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Augur : IShip
{
    public Augur(IDeflector? deflector = null)
    {
        Deflector = deflector ?? new DeflectorClass3();
    }

    public IImpulseEngine ImpulseEngine { get; } = new EClassEngine();
    public IJumpEngine JumpEngine { get; } = new AlphaJumpEngine();
    public IDeflector? Deflector { get; }
    public AntiNitreneEmitter? AntiNitreneEmitter { get; }
    public IHullStrength HullStrength { get; } = new HullStrengthClass3();
}