class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        List<int> evenNumbers = numbers.FindAll(num => num % 2 == 0);

        Console.WriteLine("Even numbers:");
        foreach (int i in evenNumbers)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}