using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.JumpEngine;

public class AlphaJumpEngine : IJumpEngine
{
    public double FuelConsumption => IJumpEngine.JumpEngineBaseFuelConsumption;

    public double MaxJumpDistance => 200;

    public bool CanJump(double distance)
    {
        return distance <= MaxJumpDistance;
    }

    public double Jump(double distance)
    {
        return FuelNeeded(distance);
    }

    public double FuelNeeded(double distance)
    {
        return distance * FuelConsumption * (double)JumpEngineFuelPricing.PricePerUnit;
    }
}