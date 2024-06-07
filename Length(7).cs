class StringProperties
{
    static void Main()
    {
        Console.WriteLine("Enter string text:");
        string userInput = Console.ReadLine()!;

        int length = userInput.Length;
        char firstChar = userInput[0];
        char lastChar = userInput[userInput.Length - 1];

        Console.WriteLine($"Your string: {userInput}");
        Console.WriteLine($"String length: {length}");
        Console.WriteLine($"First character: {firstChar}");
        Console.WriteLine($"Last character: {lastChar}");
    }
}