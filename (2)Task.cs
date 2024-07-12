// ../../../TestFiles/test.txt
// ../../../moderation.txt

Console.WriteLine("Enter text file path:");
string textFilePath = Console.ReadLine()!;
Console.WriteLine("Enter moderation file path:");
string moderationFilePath = Console.ReadLine()!;

string moderationWordsContent = File.ReadAllText(moderationFilePath);
string[] moderationWords = moderationWordsContent.Split(new[] { ' ', '\n', '\r' });
string content = File.ReadAllText(textFilePath);

foreach (string word in moderationWords)
{
    string replacement = new string('*', word.Length);
    content = content.Replace(word, replacement);
}

Console.WriteLine(content);

File.WriteAllText(textFilePath, content);