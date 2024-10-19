class Program
{
    static void Main()
    {
        Console.WriteLine("Enter URL:");
        string input = Console.ReadLine()!;

        try
        {
            Uri uri = new Uri(input);

            Console.WriteLine($"\nScheme: {uri.Scheme}\nHost: {uri.Host}\nPort: {uri.Port}\nPath: {uri.AbsolutePath}\nQuery: {uri.Query}\nFragment: {uri.Fragment}\nAbsolute address: {(uri.IsAbsoluteUri ? "Yes" : "No")}");
        }
        catch (UriFormatException)
        {
            Console.WriteLine("Invalid URL. Try again");
        }
    }
}