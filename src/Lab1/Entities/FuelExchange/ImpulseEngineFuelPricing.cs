namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelExchange;

public class ImpulseEngineFuelPricing : IFuelExchange
{
    public static decimal PricePerUnit { get; private set; }

    public static void SetPricePerUnit(decimal price)
    {
        PricePerUnit = price;
    }
}