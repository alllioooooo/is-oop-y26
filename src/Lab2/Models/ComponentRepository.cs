using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevice.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public static class ComponentRepository
{
    public static Dictionary<string, object> GetDefaultComponents()
    {
        var xmp1 = new XMP("38-38-38", 1.25, 5200);
        var xmp2 = new XMP("16-20-20", 1.35, 3200);
        var xmp3 = new XMP("38-38-38", 1.25, 4800);
        var xmp4 = new XMP("40-40-40", 1.25, 5200);
        var xmp5 = new XMP("40-40-40-89", 1.25, 5600);
        var xmp6 = new XMP("18-22-22", 1.35, 3600);
        var xmp7 = new XMP("16-18-18-38", 1.35, 3200);

        var bios1 = new BIOS("UEFI", "1.1.0", new List<string> { "INTEL Core i9 13900KF", "INTEL Core i5 13600KF OEM" });
        var bios2 = new BIOS("F15", "3.4.7", new List<string> { "INTEL Core i5 13500 OEM", "INTEL Core i3 13100F OEM" });
        var bios3 = new BIOS("Legacy", "4.4.0", new List<string> { "INTEL Core i7 13700", "INTEL Core i9 13900KS" });
        var bios4 = new BIOS("UEFI", "2.2.0", new List<string> { "INTEL Core i5 13500 OEM", "INTEL Core i3 13100F OEM" });
        var bios5 = new BIOS("Gibrid", "1.0.1", new List<string> { "INTEL Core i3 10100F" });

        return new Dictionary<string, object>
        {
            // XMP
            { "XMP 1", xmp1 },
            { "XMP 2", xmp2 },
            { "XMP 3", xmp3 },
            { "XMP 4", xmp4 },
            { "XMP 5", xmp5 },
            { "XMP 6", xmp6 },
            { "XMP 7", xmp7 },

            // CPU
            { "INTEL Core i9 13900KF", new CPU("INTEL Core i9 13900KF", 3.0, 24, "LGA1700", false, 5800, 100, 125) },
            { "INTEL Core i5 13600KF OEM", new CPU("INTEL Core i5 13600KF OEM", 3.5, 14, "LGA1700", false, 5600, 181, 125) },
            { "INTEL Core i5 13500 OEM", new CPU("INTEL Core i5 13500 OEM", 2.5, 14, "LGA1700", true, 4800, 154, 65) },
            { "INTEL Core i3 13100F OEM", new CPU("INTEL Core i3 13100F OEM", 3.4, 4, "LGA1700", false, 4800, 89, 58) },
            { "INTEL Core i7 13700", new CPU("INTEL Core i7 13700", 2.1, 16, "LGA 1700", true, 5600, 219, 65) },
            { "INTEL Core i9 13900KS", new CPU("INTEL Core i9 13900KS", 3.2, 24, "LGA 1700", true, 5600, 253, 150) },
            { "INTEL Core i3 10100F", new CPU("INTEL Core i3 10100F", 3.6, 4, "LGA 1200", false, 2666, 65, 65) },

            // BIOS
            { "BIOS 1", bios1 },
            { "BIOS 2", bios2 },
            { "BIOS 3", bios3 },
            { "BIOS 4", bios4 },
            { "BIOS 5", bios5 },

            // CoolingSystem
            { "Asus ROG RYUJIN II 360", new CoolingSystem("120x120x25", new List<string> { "AM4", "s1150", "s1151", "s1155", "s1156", "s2011", "s2011-3", "s2066", "s1200", "s1700", "AM5", "TR4", "LGA1700" }, 220) },
            { "HYPERPC WaterCooling 240 RGB", new CoolingSystem("274x120x52", new List<string> { "s1155", "s1156", "s1150", "s1151", "AM4", "s1200", "s1700", "AM5", "LGA1700" }, 220) },
            { "ID-Cooling SE-224-XTS ARGB", new CoolingSystem("120x120x25", new List<string> { "s1155", "s1156", "s1150", "s1151", "AM4", "s1200", "s1700", "AM5", "LGA1700" }, 220) },
            { "Asus ROG RYUJIN III 360", new CoolingSystem("120x120x25", new List<string> { "AM4", "s1150", "s1151", "s1155", "s1156", "s1200", "s1700", "AM5", "LGA1700" }, 220) },
            { "Deepcool LS720 Black", new CoolingSystem("120x120x25", new List<string> { "AM4", "s1150", "s1151", "s1155", "s1156", "s2011", "s2011-3", "s2066", "s1200", "s1700", "AM5", "LGA1700" }, 220) },
            { "ID-Cooling DK-03i RGB", new CoolingSystem("120x120x25", new List<string> { "s1155", "s1156", "s1150", "s1151", "s1200", "LGA 1200" }, 220) },

            // GPU
            { "Gigabyte GeForce GTX 1650", new GPU((Height: 122, Width: 40), 4096, "PCI-E 3.0", 1635, 300) },
            { "Palit GeForce RTX 4080 GameRock", new GPU((Height: 137.5, Width: 71.5), 16384, "PCI-E 4.0", 2205, 850) },
            { "NVIDIA GeForce RTX 4090", new GPU((Height: 140, Width: 77), 24576, "PCI-E 4.0", 2595, 850) },
            { "NVIDIA GeForce RTX 4080", new GPU((Height: 140, Width: 337), 16384, "PCI-E 4.0", 2610, 320) },
            { "NVIDIA GeForce RTX 4060", new GPU((Height: 123.5, Width: 249.9), 8000, "PCI-E 4.0", 1830, 115) },
            { "NVIDIA GeForce RTX 4070", new GPU((Height: 338, Width: 0), 12288, "PCI-E 4.0", 2625, 650) },

            // Motherboard
            { "GIGABYTE H510M H", new Motherboard("LGA 1200", 16, 4, "Intel H510", "DDR4", 2, "Micro-ATX", bios1) },
            { "MSI MPG Z690 EDGE WIFI", new Motherboard("LGA 1700", 40, 6, "Intel Z690", "DDR5", 4, "Standard-ATX", bios2) },
            { "MSI MPG Z790 EDGE WIFI", new Motherboard("LGA 1700", 41, 7, "Intel Z790", "DDR5", 4, "Standard-ATX", bios2) },
            { "MSI MEG Z790 ACE", new Motherboard("LGA 1700", 45, 5, "Intel Z790", "DDR5", 4, "E-ATX", bios3) },
            { "MSI PRO B760M-G DDR4", new Motherboard("LGA 1700", 8, 2, "Intel B760", "DDR4", 2, "Micro-ATX", bios4) },
            { "MSI MAG B760 TOMAHAWK WIFI", new Motherboard("LGA 1700", 41, 4, "Intel B760", "DDR5", 4, "Standard-ATX", bios2) },
            { "ASUS ROG MAXIMUS Z690 HERO", new Motherboard("LGA 1700", 3, 6, "Intel Z690", "DDR5", 4, "Standard-ATX", bios5) },

            // PCCase
            { "AEROCOOL CYLON MINI", new PCCase(300, new List<string> { "Mini-ATX", "Micro-ATX" }, "381х175х360") },
            { "LIAN LI PC-O11 DYNAMIC DESIGNED BY RAZER", new PCCase(420, new List<string> { "MICRO-ATX", "STANDARD-ATX", "E-ATX" }, "446х274х449 ") },
            { "Corsair iCUE 5000T RGB", new PCCase(400, new List<string> { "Standard-ATX", "Mini-ITX", "Micro-ATX" }, "560x251x530") },
            { "Lian Li V3000 PLUS", new PCCase(489, new List<string> { "E-ATX", "Micro-ATX", "Mini-ITX", "SSI-EEB", "Standard-ATX" }, "378х279х674") },
            { "HYPERPC CYBER", new PCCase(400, new List<string> { "E-ATX", "Micro-ATX", "Mini-ITX", "SSI-EEB", "Standard-ATX" }, "647х232х620") },
            { "MSI MAG FORGE M100R", new PCCase(300, new List<string> { "Mini-ITX", "Micro-ATX" }, "388х200х423") },
            { "HYPERPC LUMEN", new PCCase(400, new List<string> { "Mini-ATX", "Micro-ATX" }, "426x204x437") },
            { "HYTE Y60", new PCCase(375, new List<string> { "E-ATX", "Micro-ATX", "Mini-ITX", "Standard-ATX" }, "456x285x462") },

            // RAM
            { "ADATA XPG Lancer RGB", new RAM(32, new List<(int Frequency, double Voltage)> { (5200, 1.25) }, new List<XMP> { xmp1 }, "DIMM", "DDR5", 3.5) },
            { "ADATA XPG GAMMIX D10", new RAM(16, new List<(int Frequency, double Voltage)> { (3200, 1.35) }, new List<XMP> { xmp2 }, "DIMM", "DDR4", 3.7) },
            { "Kingston FURY Beast Black RGB", new RAM(32, new List<(int Frequency, double Voltage)> { (5200, 1.25) }, new List<XMP> { xmp3, xmp4 }, "DIMM", "DDR5", 3.5) },
            { "G.Skill Trident Z5 RGB", new RAM(96, new List<(int Frequency, double Voltage)> { (5600, 1.25) }, new List<XMP> { xmp5 }, "DIMM", "DDR5", 3.9) },
            { "ADATA XPG SPECTRIX D50 RGB", new RAM(16, new List<(int Frequency, double Voltage)> { (3600, 1.35) }, new List<XMP> { xmp6 }, "DIMM", "DDR4", 3.5) },
            { "G.Skill AEGIS", new RAM(16, new List<(int Frequency, double Voltage)> { (3200, 1.35) }, new List<XMP> { xmp7 }, "DIMM", "DDR4", 3.5) },

            // SSD
            { "Kingston KC3000", new SSD("PCI-E 4.0 x4", 512, 7000, 0.34) },
            { "Kingston NV2", new SSD("PCI-E 4.0 x4", 1000, 3500, 5) },
            { "Samsung 990 PRO", new SSD("PCI-E 4.0 x4", 1000, 7450, 7.8) },
            { "ADATA XPG SX8200 Pro", new SSD("PCI-E 3.x x4", 512, 3350, 0.33) },
            { "WD Black SN770", new SSD("PCI-E 4.0 x4", 1000, 5150, 6.8) },
            { "Corsair MP600 Pro XT", new SSD("PCI-E 4.0 x4", 2000, 7100, 3.3) },

            // HDD
            { "Seagate BarraCuda", new HDD(2000, 7200, 3.7) },
            { "Seagate Exos 7E2000", new HDD(1000, 7200, 3.53) },
            { "Seagate Exos X16", new HDD(12000, 7200, 5) },
            { "WD Purple Surveillance", new HDD(4000, 5400, 4.3) },
            { "WD Red IntelliPower", new HDD(4000, 5400, 3.1) },
            { "Seagate SkyHawk", new HDD(6000, 5900, 3.4) },

            // PowerSupply
            { "Phanteks AMP", new PowerSupply(1000) },
            { "Deepcool PX850G", new PowerSupply(850) },
            { "Deepcool PX1000G", new PowerSupply(1000) },
            { "Deepcool PK500D", new PowerSupply(500) },
            { "Deepcool PK650D", new PowerSupply(650) },
            { "Thermaltake Toughpower GF3", new PowerSupply(1350) },
            { "Super Flower Leadex", new PowerSupply(2000) },
            { "ASUS ROG THOR", new PowerSupply(1600) },
            { "be quiet! System Power 9", new PowerSupply(500) },
            { "Phanteks Revolt X", new PowerSupply(1200) },

            // WiFiAdapter
            { "TP-LINK Archer TX50E", new WiFiAdapter("6 (802.11ax)", true, "PCI-E", 20) },
            { "Tenda E33", new WiFiAdapter("6 (802.11ax)", true, "PCI-E", 20) },
            { "ASUS PCE-AX3000", new WiFiAdapter("6 (802.11ax)", true, "PCI-E", 20) },
            { "ASUS PCE-AC68", new WiFiAdapter("5 (802.11ac)", false, "PCI-E", 22) },
        };
    }
}