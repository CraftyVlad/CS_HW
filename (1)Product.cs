class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product("Product A", 100),
            new Product("Product B", 20),
            new Product("Product C", 300),
            new Product("Product D", 40),
            new Product("Product E", 500)
        };

        List<Product> cheapProducts = FindCheapProducts(products, 50);
        Console.WriteLine("Products with a price of less than 50 units:");
        foreach (var product in cheapProducts)
        {
            Console.WriteLine($"{product.Name}: {product.Price}");
        }

        decimal averagePrice = CalculateAveragePrice(products);
        Console.WriteLine($"\nAverage price of all products: {averagePrice}");

        List<Product> sortedProducts = SortProductsByPriceDescending(products);
        Console.WriteLine("\nThe list of products is sorted by decreasing price:");
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"{product.Name}: {product.Price}");
        }
    }
    static List<Product> FindCheapProducts(List<Product> products, decimal maxPrice)
    {
        List<Product> result = new List<Product>();
        foreach (var product in products)
        {
            if (product.Price < maxPrice)
            {
                result.Add(product);
            }
        }
        return result;
    }

    static decimal CalculateAveragePrice(List<Product> products)
    {
        if (products.Count == 0) return 0;

        decimal total = 0;
        foreach (var product in products)
        {
            total += product.Price;
        }
        return total / products.Count;
    }

    static List<Product> SortProductsByPriceDescending(List<Product> products)
    {
        List<Product> sortedProducts = new List<Product>(products);
        sortedProducts.Sort((p1, p2) => p2.Price.CompareTo(p1.Price));
        return sortedProducts;
    }
}

