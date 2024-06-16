namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder SetWifiStandard(string wifiStandard);
    IWiFiAdapterBuilder SetBluetoothModule(bool hasBluetoothModule);
    IWiFiAdapterBuilder SetPCIeVersion(string pciEVersion);
    IWiFiAdapterBuilder SetPowerConsumption(double powerConsumption);
    WiFiAdapter Build();
}