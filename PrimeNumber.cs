class PrimeNumber
{
    static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
    static void Main()
    {
        Console.Write("Enter an integer: ");
        string input = Console.ReadLine()!;

        int number;
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        if (IsPrime(number))
        {
            Console.WriteLine($"{number} is a prime number.");
        }
        else
        {
            Console.WriteLine($"{number} is not a prime number.");
        }
    }

    
}
