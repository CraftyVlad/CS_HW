public static class Max
{
    public static int FindMax(this (int, int, int) numbers)
    {
        return Math.Max(Math.Max(numbers.Item1, numbers.Item2), numbers.Item3);
    }
}

class Program
{
    static void Main()
    {
        var numbers = (654, 698, 546);
        int maxNumber = numbers.FindMax();
        Console.WriteLine(maxNumber);
    }
}