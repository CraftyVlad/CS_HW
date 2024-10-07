class Program
{
    static async Task Main()
    {
        Console.WriteLine("Enter path for file that you want to copy:");
        string sourcePath = Console.ReadLine()!;

        string destinationDirectory = "../../../";

        string fileName = Path.GetFileName(sourcePath);

        string destinationPath = Path.Combine(destinationDirectory, fileName);

        Task copyTask = Task.Run(() => CopyFile(sourcePath, destinationPath));

        while (!copyTask.IsCompleted)
        {
            Console.WriteLine("Main thread running. Type something to test input:");
            string input = Console.ReadLine()!;
            Console.WriteLine($"You entered: {input}");
        }

        await copyTask;
        Console.WriteLine($"File copied to '{destinationPath}'");
    }

    static void CopyFile(string source, string destination)
    {
        using (FileStream sourceStream = File.Open(source, FileMode.Open))
        {
            using (FileStream destinationStream = File.Create(destination))
            {
                sourceStream.CopyTo(destinationStream);
            }
        }
    }
}