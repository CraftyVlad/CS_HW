public class Book
{
    public string title { get; set; }
    public string author { get; set; }
    public double price { get; set; }

    // constructor
    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {title}, Author: {author}, Price: {price}");
    }

    // deconstructor
    ~Book()
    {

    }
}

class Program
{
    static void Main()
    {
        Book book = new Book("C# programming", "John D.", 50);

        book.DisplayInfo();
    }
}