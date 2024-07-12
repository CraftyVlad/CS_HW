string filePath = "../../../TestFiles/test.txt";

string content = File.ReadAllText(filePath);
char[] charArray = content.ToCharArray();
Array.Reverse(charArray);

string reversedContent = new string(charArray);
string newFilePath = Path.Combine(Path.GetDirectoryName(filePath)!, "reversed_" + Path.GetFileName(filePath));

File.WriteAllText(newFilePath, reversedContent);
Console.WriteLine($"New file with reversed content: {newFilePath}");