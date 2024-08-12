using System.Text.Json;

public class Magazine
{

    public string Title {  get; set; }
    public string Publisher { get; set; }
    public DateTime PublicationDate { get; set; }
    public int PageCount { get; set; }

    public override string ToString()
    {
        return $"Назва: {Title}, Видатництво: {Publisher}, Дата видання: {PublicationDate}, Кількість сторінок: {PageCount}";
    }
}

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть назву журналу:");
        string title = Console.ReadLine()!;

        Console.WriteLine("Введіть назву видавця:");
        string publisher = Console.ReadLine()!;

        Console.WriteLine("Введіть дату видання (yyyy-mm-dd):");
        DateTime publicationDate = DateTime.Parse(Console.ReadLine()!);

        Console.WriteLine("Введіть кількість сторінок:");
        int pageCount = int.Parse(Console.ReadLine()!);

        Magazine magazine = new Magazine
        {
            Title = title,
            Publisher = publisher,
            PublicationDate = publicationDate,
            PageCount = pageCount
        };

        Console.WriteLine("Інформвція про журнал:");
        Console.WriteLine(magazine);

        string jsonString = JsonSerializer.Serialize(magazine);
        File.WriteAllText("../../../magazine.json", jsonString);
        Console.WriteLine("Інформація про журнал збережена у файл 'magazine.json'.");

        string loadedJsonString = File.ReadAllText("../../../magazine.json");
        Magazine loadedMagazine = JsonSerializer.Deserialize< Magazine>(loadedJsonString)!;

        Console.WriteLine($"Завантажена інформація про журнал: '{loadedMagazine}'.");
    }
}