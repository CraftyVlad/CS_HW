public class Store : IDisposable
{
    public string StoreName { get; set; }
    public string StoreAddress { get; set; }
    public string StoreType { get; set; }
    private bool disposed = false;

    public Store(string storeName, string storeAddress, string storeType)
    {
        StoreName = storeName;
        StoreAddress = storeAddress;
        StoreType = storeType;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Store Name: {StoreName}");
        Console.WriteLine($"Store Address: {StoreAddress}");
        Console.WriteLine($"Store Type: {StoreType}");
    }

    public void Dispose()
    {
        Dispose(true);
    }

    void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine("Closing store");
            }
            disposed = true;
        }
    }

    ~Store()
    {
        Dispose(false);
    }
}

class Program
{
    static void Main()
    {
        Store store = new Store("Good Store", "123 Main St", "Grocery");
        store.DisplayInfo();

        Store anotherStore = new Store("Better Store", "456 High St", "Clothing");
        anotherStore.DisplayInfo();
        anotherStore.Dispose();
    }
}
