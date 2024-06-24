class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main()
    {
        int age = 15;
        try
        {
            CheckAge(age);
            Console.WriteLine("The age is valid: " + age);
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void CheckAge(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException("The age must be at least 18.");
        }
    }
}