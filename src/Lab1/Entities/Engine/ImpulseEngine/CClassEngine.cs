using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.ImpulseEngine;

public class CClassEngine : IImpulseEngine
{
    private const double CClassEngineBaseFuelConsumption = 1.0;
    public double MaxMoveDistance => 50;
    public double FuelConsumption => CClassEngineBaseFuelConsumption;

    public double Move(double distance)
    {
        return FuelNeeded(distance);
    }

    public double FuelNeeded(double distance)
    {
        return FuelConsumption * (double)ImpulseEngineFuelPricing.PricePerUnit;
    }

    public bool CanMove(double distance)
    {
        return distance <= MaxMoveDistance;
    }
}