using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath = "../../../testing";

        // Prompt the user for the max execution time.
        Console.WriteLine("Enter the maximum execution time in seconds:");
        if (!int.TryParse(Console.ReadLine(), out int maxExecutionTimeInSeconds) || maxExecutionTimeInSeconds <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid number of seconds.");
            return;
        }

        Console.WriteLine($"Processing files in directory: {directoryPath}");
        Console.WriteLine($"Max execution time: {maxExecutionTimeInSeconds} seconds");

        // Get all files in the specified directory.
        string[] files = Directory.GetFiles(directoryPath);
        foreach (string file in files)
        {
            Console.WriteLine($"File found: {Path.GetFileName(file)}");
        }

        CancellationTokenSource cts = new CancellationTokenSource();
        Task.Run(() => MainThreadCheckForInput(cts), cts.Token);

        // Run the file processing task with a cancellation token.
        var processingTask = ProcessFilesAsync(files, cts.Token);

        // Set up the cancellation timeout.
        cts.CancelAfter(TimeSpan.FromSeconds(maxExecutionTimeInSeconds));

        try
        {
            processingTask.Wait(cts.Token); // Wait for the task to complete or be canceled.
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

    // Simulate processing files asynchronously.
    static async Task ProcessFilesAsync(string[] files, CancellationToken token)
    {
        foreach (string file in files)
        {
            try
            {
                Console.WriteLine($"Processing file: {Path.GetFileName(file)}");

                // Simulate file processing by writing a large amount of data.
                string newData = new string('X', 1000000); // Replace with smaller string for testing.
                using (StreamWriter writer = new StreamWriter(file, false, Encoding.UTF8))
                {
                    await writer.WriteAsync(newData.AsMemory(), token);
                }

                // Simulate some delay for each file to make the process long.
                await Task.Delay(2000, token); // Simulate delay for processing (2 seconds per file).
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Processing of {Path.GetFileName(file)} was canceled. Clearing all files.");
                // Cancel all files when any cancellation happens.
                ClearAllFiles(files);
                throw; // Rethrow to propagate the cancellation.
            }

            if (token.IsCancellationRequested)
            {
                Console.WriteLine($"Cancellation requested. Clearing all files.");
                ClearAllFiles(files); // Clear all files upon cancellation.
                //if (File.ReadAllLines(file) == null)
                //{
                //    Console.WriteLine("JJJJJJJJJJJJJ");
                //}
                token.ThrowIfCancellationRequested();
            }
        }
    }

    // Method to clear all files in case of cancellation.
    static void ClearAllFiles(string[] files)
    {
        foreach (string file in files)
        {
            try
            {
                // Clear the content of each file.
                File.WriteAllText(file, string.Empty);
                Console.WriteLine($"Cleared content of file: {Path.GetFileName(file)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to clear file {Path.GetFileName(file)}: {ex.Message}");
            }
        }
    }

    // This method runs on the main thread, checking for user input.
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
