class SumOfDigits
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        string input = Console.ReadLine()!;

        int number;
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("Invalid integer.");
            return;
        }

        int sum = 0;
        int tempNumber = number;

        while (tempNumber != 0)
        {
            sum += tempNumber % 10;
            tempNumber /= 10;
        }

        Console.WriteLine($"The sum of the digits of {number} is equal to {sum}.");
    }
}
