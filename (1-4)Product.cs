public interface IProduct : IComparable<IProduct>
{
    string Name { get; set; }
    decimal Price { get; set; }
    int Quantity { get; set; }

    void IncreaseQuantity(int amount);
    void DecreaseQuantity(int amount);
    IProduct Clone();
}

public class Product : IProduct
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void IncreaseQuantity(int amount)
    {
        Quantity += amount;
    }

    public void DecreaseQuantity(int amount)
    {
        if (amount > Quantity)
        {
            throw new ArgumentException("Amount to decrease exceeds the current quantity.");
        }
        Quantity -= amount;
    }

    public int CompareTo(IProduct other)
    {
        if (other == null) return 1;
        return this.Price.CompareTo(other.Price);
    }

    public IProduct Clone()
    {
        return new Product(this.Name, this.Price, this.Quantity);
    }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}, Quantity: {Quantity}";
    }
}

public interface IRepository<T>
{
    void Add(T item);
    void Remove(T item);
    T Get(int index);
}

public class ProductRepository<T> : IRepository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public T Get(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
        return items[index];
    }

    public List<T> GetAll()
    {
        return new List<T>(items);
    }
}

public class Program
{
    public static void Main()
    {
        List<IProduct> products = new List<IProduct>
        {
            new Product("Product A", 10, 5),
            new Product("Product B", 5, 10),
            new Product("Product C", 8, 3)
        };

        products.Sort();

        Console.WriteLine("Sorted products by price:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        IProduct originalProduct = new Product("Product D", 15.00m, 2);
        IProduct clonedProduct = originalProduct.Clone();
        Console.WriteLine("\nOriginal product: " + originalProduct);
        Console.WriteLine("Cloned product: " + clonedProduct);

        ProductRepository<IProduct> repository = new ProductRepository<IProduct>();
        repository.Add(originalProduct);
        repository.Add(clonedProduct);

        Console.WriteLine("\nProducts in repository:");
        foreach (var item in repository.GetAll())
        {
            Console.WriteLine(item);
        }
    }
}
