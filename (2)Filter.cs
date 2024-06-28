class Program
{
    static void Filter(List<int> numbers, Func<int, bool> condition, List<int> filteredList)
    {
        Console.WriteLine("Filtered list:");
        foreach (int i in filteredList)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Filter(numbers, delegate (int i) { return i % 2 == 0; }, numbers.FindAll(delegate (int i) { return i % 2 == 0; }));

        Filter(numbers, delegate (int i) { return i > 5; }, numbers.FindAll(delegate (int i) { return i > 5; }));
    }
}