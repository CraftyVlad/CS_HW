class WordReplacement
{
    static void Main()
    {
        Console.WriteLine("Enter string:");
        string userInput = Console.ReadLine()!;

        Console.WriteLine("Enter word to replace:");
        string wordToReplace = Console.ReadLine()!;

        Console.WriteLine("Enter new word:");
        string replacementWord = Console.ReadLine()!;

        string replacedString = userInput.Replace(wordToReplace, replacementWord);

        Console.WriteLine($"New string: {replacedString}");

        string[] words = replacedString.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Words in string:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}
