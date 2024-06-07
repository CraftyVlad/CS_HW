class Week
{
    enum DayOfWeek
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    static void Main()
    {
        Console.WriteLine("Enter a number from 1 to 7:");
        int userInput = Convert.ToInt32(Console.ReadLine());

        if (userInput >= 1 && userInput <= 7)
        {
            DayOfWeek day = (DayOfWeek)userInput;
            Console.WriteLine("You selected: " + day);
        }
        else
        {
            Console.WriteLine("Invalid choice. Choose a number from 1 to 7.");
        }
    }
}
