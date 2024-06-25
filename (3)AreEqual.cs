class Program
{
    static bool AreEqual<T>(T a, T b)
    {
        return EqualityComparer<T>.Default.Equals(a, b);
    }

    static void Main()
    {
        int num1 = 1;
        int num2 = 1;
        bool result1 = AreEqual(num1, num2);
        Console.WriteLine($"Are {num1} and {num2} equal? {result1}");

        string str1 = "Hello";
        string str2 = "World!";
        bool result2 = AreEqual(str1, str2);
        Console.WriteLine($"Are {str1} and {str2} equal? {result2}");
    }
}