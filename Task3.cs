class Bridge
{
    AutoResetEvent BridgeLock = new AutoResetEvent(true);
    string currentDirection = null;

    public void CrossBridge(int carId, string direction)
    {
        BridgeLock.WaitOne();

        if (currentDirection == null || currentDirection == direction)
        {
            currentDirection = direction;
            Console.WriteLine($"Car {carId} is moving {direction}");
            Console.WriteLine($"Car {carId} has left the bridge");
            currentDirection = null;
        }

        BridgeLock.Set();
    }
}

class Car
{
    public int Id { get; set; }
    public string Direction { get; set; }

    public Car(int id, string direction)
    {
        Id = id;
        Direction = direction;
    }
}

class Program
{
    static void CarThread(object carObj)
    {
        Car car = (Car)carObj;
        Bridge bridge = new Bridge();
        Thread.Sleep(new Random().Next(1000, 3000));
        bridge.CrossBridge(car.Id, car.Direction);
    }

    static void Main()
    {
        Bridge bridge = new Bridge();
        int numCars = 5;
        Thread[] carThreads = new Thread[numCars];

        for (int i = 0; i < numCars; i++)
        {
            string direction = new Random().Next(0, 2) == 0 ? "left" : "right";
            Car car = new Car(i, direction);

            carThreads[i] = new Thread(new ParameterizedThreadStart(CarThread));
            carThreads[i].Start(car);
        }

        foreach (var carThread in carThreads)
        {
            carThread.Join();
        }
    }
}