class Increment
{
    static void Main()
    {
        int number = 1;
        Console.WriteLine("Starting number: " + number);

        static void IncrementNumber(ref int number)
        {
            number++;
        }

        IncrementNumber(ref number);
        Console.WriteLine("After increment: " + (number));
    }
}
