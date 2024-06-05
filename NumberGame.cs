class NumberGame
{
    static void Main()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 101);

        Console.WriteLine("Try and guess a number from 1 to 100.");

        int guess = 0;
        while (guess != randomNumber)
        {
            Console.Write("Enter your guess: ");
            if (!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.WriteLine("Invalid number.");
                continue;
            }

            if (guess < randomNumber)
            {
                Console.WriteLine("Your guess is smaller than the random number.");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("Your guess is larger than the random number.");
            }
        }

        Console.WriteLine("You guessed the correct number! It was " + randomNumber + ".");
    }
}
