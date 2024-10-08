using System.Text;

class Program
{
    static void Main(string[] args)
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
        Task.Run(() => MainThreadCheckForInput(cts), cts.Token);

        var processingTask = ProcessFilesAsync(files, cts.Token);

        cts.CancelAfter(TimeSpan.FromSeconds(maxExecutionTimeInSeconds));

        try
        {
            processingTask.Wait(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Processing canceled due to time limit exceeded.");
        }
        catch (AggregateException ex)
        {
            foreach (var inner in ex.InnerExceptions)
            {
                if (inner is OperationCanceledException)
                    Console.WriteLine("Processing canceled due to time limit exceeded.");
                else
                    Console.WriteLine(inner.Message);
            }
        }

        Console.WriteLine("Program has finished.");
    }

    static async Task ProcessFilesAsync(string[] files, CancellationToken token)
    {
        foreach (string file in files)
        {
            try
            {
                Console.WriteLine($"Processing file: {Path.GetFileName(file)}");

                string newData = new string('X', 1000000);
                using (StreamWriter writer = new StreamWriter(file, false, Encoding.UTF8))
                {
                    await writer.WriteAsync(newData.AsMemory(), token);
                }

                await Task.Delay(2000, token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Processing of {Path.GetFileName(file)} was canceled. Clearing all files.");
                ClearAllFiles(files);
                throw;
            }

            if (token.IsCancellationRequested)
            {
                Console.WriteLine($"Cancellation requested. Clearing all files.");
                ClearAllFiles(files);
                token.ThrowIfCancellationRequested();
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

    static void MainThreadCheckForInput(CancellationTokenSource cts)
    {
        Console.WriteLine("Main thread continues to run. Type 'cancel' to stop processing early.");

        while (!cts.Token.IsCancellationRequested)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadLine();
                if (key != null && key.ToLower() == "cancel")
                {
                    Console.WriteLine("Cancellation requested by user.");
                    cts.Cancel();
                    break;
                }
            }
        }
    }
}
