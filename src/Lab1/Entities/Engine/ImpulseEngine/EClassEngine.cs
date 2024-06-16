using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine.ImpulseEngine;

public class EClassEngine : IImpulseEngine
{
    private const double EClassEngineBaseFuelConsumption = 5.0;
    public double MaxMoveDistance => 100;
    public double FuelConsumption => EClassEngineBaseFuelConsumption;

    public double Move(double distance)
    {
        return FuelNeeded(distance);
    }

    public double FuelNeeded(double distance)
    {
        return Math.Exp(distance) * FuelConsumption * (double)ImpulseEngineFuelPricing.PricePerUnit;
    }

    public bool CanMove(double distance)
    {
        return distance <= MaxMoveDistance;
    }
}