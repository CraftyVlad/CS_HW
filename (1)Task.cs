try
{
    string directoryPath = "../../../TestFiles";

    Console.Write("Enter the word to be replaced: ");
    string wordToReplace = Console.ReadLine()!;
    Console.Write("Enter the replacement word: ");
    string replacementWord = Console.ReadLine()!;

    ReplaceWordInFiles(directoryPath, wordToReplace, replacementWord);

    Console.WriteLine("\nReplacement completed.");
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}


static void ReplaceWordInFiles(string directoryPath, string wordToReplace, string replacementWord)
{
    string[] files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);

    foreach (string filePath in files)
    {
        try
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine($"\nContent before change in file {filePath}: \n{content}\n");

            string modifiedContent = content.Replace(wordToReplace, replacementWord);

            File.WriteAllText(filePath, modifiedContent);

            Console.WriteLine($"Content after change in file {filePath}: \n{modifiedContent}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while processing file {filePath}: " + ex.Message);
        }
    }
}

