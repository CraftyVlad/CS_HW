class Utility
{
    public static void Swap<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }
}

class Program
{
    static void Main()
    {
        int x = 1;
        int y = 2;
        Console.WriteLine($"Numbers before swap: {x}, {y}.");
        Utility.Swap(ref x, ref y);
        Console.WriteLine($"Numbers after swap: {x}, {y}.");

        string str1 = "Hello";
        string str2 = "World!";
        Console.WriteLine($"Strings before swap: {str1}, {str2}.");
        Utility.Swap(ref str1, ref str2);
        Console.WriteLine($"Strings after swap: {str1}, {str2}.");
    }
}