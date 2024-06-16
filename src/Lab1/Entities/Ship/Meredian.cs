using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Meredian : IShip
{
    public Meredian(IDeflector? deflector = null)
    {
        Deflector = deflector ?? new DeflectorClass2();
    }

    public IImpulseEngine ImpulseEngine { get; } = new EClassEngine();
    public AntiNitreneEmitter AntiNitreneEmitter { get; } = new();
    public IJumpEngine? JumpEngine { get; }
    public IDeflector? Deflector { get; }
    public IHullStrength HullStrength { get; } = new HullStrengthClass2();
}