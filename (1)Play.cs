class Play : IDisposable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    bool disposed = false;

    public Play(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Year: {Year}\n");
    }

    void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine("Deleting play.");
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }

    ~Play()
    {
        Console.WriteLine($"Play {Title} has being destroyed.");
    }
}

class Program
{
    static void Main()
    {
        Play play1 = new Play("PlayTitle1", "PlayAuthor1", "PlayGenre1", 2024);
        Play play2 = new Play("PlayTitle2", "PlayAuthor2", "PlayGenre2", 2023);

        play1.DisplayInfo();
        play2.DisplayInfo();
        play2.Dispose();
    }
}