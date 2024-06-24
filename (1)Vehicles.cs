public class Vehicle
{
    public string Make { get; set; } = "";
    public string Model { get; set; } = "";
}

public class Car : Vehicle
{
    public int Doors { get; set; }
}

public class Motocycle : Vehicle
{
    public string Type { get; set; } = "";
}

public class Program
{
    public static void Main()
    {
        Vehicle car = new Car { Make = "Toyota", Model = "Prada", Doors = 4 };
        Vehicle motorcycle = new Motocycle { Make = "Honda", Model = "JUNO K", Type = "Classic" };

        Console.Write($"{car.Make}, {car.Model}, Number of doors: {((Car)car).Doors}\n");
        Console.Write($"{motorcycle.Make}, {motorcycle.Model}, Motorcycle type: {((Motocycle)motorcycle).Type}");
    }
}