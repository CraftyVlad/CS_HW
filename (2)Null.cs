public class StringHelper
{
    public static void CheckNullOrEmpty(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentNullException(nameof(str), "String cannot be null or empty.");
        }
    }
}

class Program
{
    public static void Main()
    {
        string testString = "";

        try
        {
            StringHelper.CheckNullOrEmpty(testString);
            Console.WriteLine("String is null or empty.");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
