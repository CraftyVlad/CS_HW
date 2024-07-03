class Phone
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Phone(string name, string manufacturer, decimal price, DateTime releaseDate)
    {
        Name = name;
        Manufacturer = manufacturer;
        Price = price;
        ReleaseDate = releaseDate;
    }

    public override string ToString()
    {
        return $"{Name} ({Manufacturer}) - ${Price} - Released on: {ReleaseDate.ToShortDateString()}";
    }
}

class Program
{
    static void Main()
    {
        var phones = new List<Phone>
        {
            new Phone("Phone1", "ManufacturerA", 500, new DateTime(2022, 1, 1)),
            new Phone("Phone2", "ManufacturerB", 300, new DateTime(2023, 6, 1)),
            new Phone("Phone3", "ManufacturerA", 700, new DateTime(2020, 3, 15)),
            new Phone("Phone4", "ManufacturerC", 150, new DateTime(2021, 11, 20))
        };

        int countPhones = phones.Count;
        Console.WriteLine($"Amount of phones: {countPhones}");

        int countPhonesOver100 = phones.Count(p => p.Price > 100);
        Console.WriteLine($"Amount of phones over price 100: {countPhonesOver100}");

        int countPhonesInRange = phones.Count(p => p.Price >= 400 && p.Price <= 700);
        Console.WriteLine($"Amound of phones from price 400 to 700: {countPhonesInRange}");

        string targetManufacturer = "ManufacturerA";
        int countPhonesByManufacturer = phones.Count(p => p.Manufacturer == targetManufacturer);
        Console.WriteLine($"Phones by {targetManufacturer}: {countPhonesByManufacturer}");

        var minPrice = phones.OrderBy(p => p.Price).FirstOrDefault();
        Console.WriteLine($"Phone minimum price: {minPrice}");

        var maxPrice = phones.OrderByDescending(p => p.Price).FirstOrDefault();
        Console.WriteLine($"Phone maximum price: {maxPrice}");

        var oldestPhone = phones.OrderBy(p => p.ReleaseDate).FirstOrDefault();
        Console.WriteLine("Older phone model: " + oldestPhone);

        var newestPhone = phones.OrderByDescending(p => p.ReleaseDate).FirstOrDefault();
        Console.WriteLine("Newest phone model: " + newestPhone);

        var averagePrice = phones.Average(p => p.Price);
        Console.WriteLine("Average price: " + averagePrice);

        var fiveCheapestPhones = phones.OrderBy(p => p.Price).Take(5).ToArray();
        Console.WriteLine("Five cheapest phones:");
        foreach (var phone in fiveCheapestPhones)
        {
            Console.WriteLine(phone);
        }

        var threeOldestPhones = phones.OrderBy(p => p.ReleaseDate).Take(3).ToArray();
        Console.WriteLine("Three oldest phones:");
        foreach (var phone in threeOldestPhones)
        {
            Console.WriteLine(phone);
        }

        var threeNewestPhones = phones.OrderByDescending(p => p.ReleaseDate).Take(3).ToArray();
        Console.WriteLine("Three newest phones:");
        foreach (var phone in threeNewestPhones)
        {
            Console.WriteLine(phone);
        }

        var phonesByManufacturer = phones.GroupBy(p => p.Manufacturer)
                                         .Select(g => new { Manufacturer = g.Key, Count = g.Count() })
                                         .ToArray();
        Console.WriteLine("Phones by manufacturer:");
        foreach (var group in phonesByManufacturer)
        {
            Console.WriteLine($"{group.Manufacturer} - {group.Count}");
        }

        var phonesByModel = phones.GroupBy(p => p.Name)
                                  .Select(g => new { Model = g.Key, Count = g.Count() })
                                  .ToArray();
        Console.WriteLine("Phones by model:");
        foreach (var group in phonesByModel)
        {
            Console.WriteLine($"{group.Model} - {group.Count}");
        }

        var phonesByYear = phones.GroupBy(p => p.ReleaseDate.Year)
                                 .Select(g => new { Year = g.Key, Count = g.Count() })
                                 .ToArray();
        Console.WriteLine("Phones by year:");
        foreach (var group in phonesByYear)
        {
            Console.WriteLine($"{group.Year} - {group.Count}");
        }
    }
}