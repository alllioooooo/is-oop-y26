using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.JumpEngine;

public class OmegaJumpEngine : IJumpEngine
{
    public double MaxJumpDistance => 1000;

    public double FuelConsumption => IJumpEngine.JumpEngineBaseFuelConsumption;

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
        return distance * Math.Log(distance) * FuelConsumption * (double)JumpEngineFuelPricing.PricePerUnit;
    }
}