namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.ImpulseEngine;

public interface IImpulseEngine : IEngine
{
    double MaxMoveDistance { get; }
    double Move(double distance);
    bool CanMove(double distance);
}