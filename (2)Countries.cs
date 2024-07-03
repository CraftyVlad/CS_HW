class Program
{
    static void Main()
    {
        string[] countries1 = { "Ukraine", "USA", "Mexico", "France" };
        string[] countries2 = { "USA", "Canada", "Ukraine", "Spain" };

        var difference = countries1.Except(countries2).ToArray();
        Console.WriteLine("Difference: " + string.Join(", ", difference));

        var intersection = countries1.Intersect(countries2).ToArray();
        Console.WriteLine("Intersection: " + string.Join(", ", intersection));

        var union = countries1.Union(countries2).ToArray();
        Console.WriteLine("Union: " + string.Join(", ", union));

        var distinct = countries1.Distinct().ToArray();
        Console.WriteLine("Distinct: " + string.Join(", ", distinct));
    }
}