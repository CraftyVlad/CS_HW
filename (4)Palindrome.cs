public static class StringPalindrome
{
    public static bool IsPalindrome(this string str)
    {
        string cleanStr = str.Replace(" ", "").ToLower();

        for (int i = 0; i < cleanStr.Length / 2; i++)
        {
            if (cleanStr[i] != cleanStr[cleanStr.Length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        string str1 = "Racecar";
        Console.WriteLine(str1.IsPalindrome());

        string str2 = "Hello World!";
        Console.WriteLine(str2.IsPalindrome());
    }
}