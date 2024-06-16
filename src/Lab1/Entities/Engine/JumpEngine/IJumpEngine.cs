namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.JumpEngine;

public interface IJumpEngine : IEngine
{
    public const double JumpEngineBaseFuelConsumption = 10.0;
    double MaxJumpDistance { get; }
    double Jump(double distance);
    bool CanJump(double distance);
}
