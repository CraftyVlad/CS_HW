using System.Text;
class StringBuilderTask
{
    static void Main()
    {
        int lineCount = 1000;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < lineCount; i++)
        {
            sb.Append("Line number: " + (i + 1) + Environment.NewLine);
        }
        Console.WriteLine(sb.ToString());
    }
}