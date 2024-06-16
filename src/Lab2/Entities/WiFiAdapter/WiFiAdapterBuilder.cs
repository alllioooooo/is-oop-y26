namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private string _wifiStandard;
    private bool _hasBluetoothModule;
    private string _pciEVersion;
    private double _powerConsumption;

    public WiFiAdapterBuilder(WiFiAdapter wifiAdapter)
    {
        WiFiAdapter newWifiAdapter = wifiAdapter.Clone();
        _wifiStandard = newWifiAdapter.WifiStandard;
        _hasBluetoothModule = newWifiAdapter.HasBluetoothModule;
        _pciEVersion = newWifiAdapter.PCIeVersion;
        _powerConsumption = newWifiAdapter.PowerConsumption;
    }

    public IWiFiAdapterBuilder SetWifiStandard(string wifiStandard)
    {
        _wifiStandard = wifiStandard;
        return this;
    }

    public IWiFiAdapterBuilder SetBluetoothModule(bool hasBluetoothModule)
    {
        _hasBluetoothModule = hasBluetoothModule;
        return this;
    }

    public IWiFiAdapterBuilder SetPCIeVersion(string pciEVersion)
    {
        _pciEVersion = pciEVersion;
        return this;
    }

    public IWiFiAdapterBuilder SetPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(_wifiStandard, _hasBluetoothModule, _pciEVersion, _powerConsumption);
    }
}