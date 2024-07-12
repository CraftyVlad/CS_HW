string inputFilePath = "../../../numbers.txt";
string positiveOutputFilePath = "../../../positive_numbers.txt";
string negativeOutputFilePath = "../../../negative_numbers.txt";

static void WriteToFile(string filePath, string content)
{
    if (File.Exists(filePath))
    {
        File.WriteAllText(filePath, String.Empty);
    }

    using (StreamWriter sw = File.AppendText(filePath))
    {
        sw.WriteLine(content);
    }
}

string[] lines = File.ReadAllLines(inputFilePath);
int[] numbers = lines.Select(int.Parse).ToArray();

int positiveCount = numbers.Count(n => n > 0);
int negativeCount = numbers.Count(n => n < 0);

string positive = $"Positive numbers: {positiveCount}";
string negative = $"Negative numbers: {negativeCount}";

WriteToFile(positiveOutputFilePath, positive);
WriteToFile(negativeOutputFilePath, negative);

Console.WriteLine($"Positive and negative numbers have been written to files: {positiveOutputFilePath} and {negativeOutputFilePath}.");