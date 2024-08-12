using System.Text.Json;

public class Fraction
{

    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction()
    {
    }

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

class Fractions
{
    static void Main()

    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Fraction> fractions = new List<Fraction>();

        Console.WriteLine("Введіть кількість дробів:");
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введіть чисельник для дробу {i + 1}:");
            int numerator = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Введіть знаменник для дробу {i + 1}:");
            int denominator = int.Parse(Console.ReadLine()!);

            fractions.Add(new Fraction(numerator, denominator));
        }

        string jsonString = JsonSerializer.Serialize(fractions);
        Console.WriteLine("Серіалізований масив дробів:");
        Console.WriteLine(jsonString);

        File.WriteAllText("../../../fractions.json", jsonString);
        Console.WriteLine("Масив збережено у файл fractions.json.");

        string loadedJsonString = File.ReadAllText("../../../fractions.json");
        List<Fraction> loadedFractions = JsonSerializer.Deserialize<List<Fraction>>(loadedJsonString)!;

        Console.WriteLine("Завантажений та десеріалізований масив дробів:");
        foreach (var fraction in loadedFractions)
        {
            Console.WriteLine(fraction);
        }
    }
}
