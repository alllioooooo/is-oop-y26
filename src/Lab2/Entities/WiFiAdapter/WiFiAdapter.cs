namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WiFiAdapter
{
    public WiFiAdapter(string wifiStandard, bool hasBluetoothModule, string pciEVersion, double powerConsumption)
    {
        WifiStandard = wifiStandard;
        HasBluetoothModule = hasBluetoothModule;
        PCIeVersion = pciEVersion;
        PowerConsumption = powerConsumption;
    }

    public string WifiStandard { get; private set; }
    public bool HasBluetoothModule { get; private set; }
    public string PCIeVersion { get; private set; }
    public double PowerConsumption { get; private set; }

    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(WifiStandard, HasBluetoothModule, PCIeVersion, PowerConsumption);
    }
}