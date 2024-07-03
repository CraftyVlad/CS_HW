class Device
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public decimal Price { get; set; }

    public Device(string name, string manufacturer, decimal price)
    {
        Name = name;
        Manufacturer = manufacturer;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} ({Manufacturer}) - ${Price}";
    }
}

class DeviceManufacturerComparer : IEqualityComparer<Device>
{
    public bool Equals(Device x, Device y)
    {
        return x.Manufacturer == y.Manufacturer;
    }

    public int GetHashCode(Device obj)
    {
        return obj.Manufacturer.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        var devices1 = new List<Device>
        {
            new Device("Device1", "ManufacturerA", 10),
            new Device("Device2", "ManufacturerB", 20),
            new Device("Device3", "ManufacturerC", 30)
        };

        var devices2 = new List<Device>
        {
            new Device("Device4", "ManufacturerB", 15),
            new Device("Device5", "ManufacturerC", 20),
            new Device("Device6", "ManufacturerD", 40)
        };

        var comparer = new DeviceManufacturerComparer();

        var difference = devices1.Except(devices2, comparer).ToArray();
        Console.WriteLine("Difference:");
        foreach (var device in difference)
        {
            Console.WriteLine(device);
        }

        var intersection = devices1.Intersect(devices2, comparer).ToArray();
        Console.WriteLine("Intersection:");
        foreach (var device in intersection)
        {
            Console.WriteLine(device);
        }

        var union = devices1.Union(devices2, comparer).ToArray();
        Console.WriteLine("Union:");
        foreach (var device in union)
        {
            Console.WriteLine(device);
        }
    }
}