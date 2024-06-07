class FlippedArray
{
    static void Main()
    {
        string[] myArray = { "red", "blue", "green", "yellow" };

        Console.WriteLine("Original: " + string.Join(", ", myArray));

        Array.Reverse(myArray);

        Console.WriteLine("Flipped: " + string.Join(", ", myArray));
    }
}
