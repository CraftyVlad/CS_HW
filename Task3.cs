class Program
{
    static void Main()
    {
        string directoryPath = "../../../testing";

        Console.WriteLine("Enter the maximum execution time in seconds:");
        if (!int.TryParse(Console.ReadLine(), out int maxExecutionTimeInSeconds) || maxExecutionTimeInSeconds <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid number of seconds.");
            return;
        }

        Console.WriteLine($"Processing files in directory: {directoryPath}");
        Console.WriteLine($"Max execution time: {maxExecutionTimeInSeconds} seconds");

        string[] files = Directory.GetFiles(directoryPath);
        foreach (string file in files)
        {
            Console.WriteLine($"File found: {Path.GetFileName(file)}");
        }

        CancellationTokenSource cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromSeconds(maxExecutionTimeInSeconds));

        try
        {
            ProcessFiles(files, cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Processing canceled due to time limit exceeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Program has finished.");
    }

    static void ProcessFiles(string[] files, CancellationToken token)
    {
        foreach (string file in files)
        {
            try
            {
                Console.WriteLine($"Processing file: {Path.GetFileName(file)}");

                string newData = new string('X', 10000);
                using (StreamWriter writer = new StreamWriter(file, false))
                {
                    writer.Write(newData);
                }

                if (token.WaitHandle.WaitOne(1000))
                {
                    throw new OperationCanceledException();
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Processing of {Path.GetFileName(file)} was canceled. Clearing all files.");
                ClearAllFiles(files);
                throw;
            }

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested. Clearing all files.");
                ClearAllFiles(files);
                throw new OperationCanceledException();
            }
        }
    }

    static void ClearAllFiles(string[] files)
    {
        foreach (string file in files)
        {
            try
            {
                File.WriteAllText(file, string.Empty);
                Console.WriteLine($"Cleared content of file: {Path.GetFileName(file)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to clear file {Path.GetFileName(file)}: {ex.Message}");
            }
        }
    }
}
