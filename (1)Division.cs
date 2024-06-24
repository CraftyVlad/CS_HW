class Program
{
    static void Main()
    {
        try
        {
            Calculate(10, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void Calculate(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Attempted to divide by zero.");
        }
        if (a < 0 || b < 0)
        {
            ArgumentException ex = new ArgumentException("Number is less than 0.");
            throw ex;
        }

        int result = a / b;
        Console.WriteLine($"Result: {result}");
    }
}