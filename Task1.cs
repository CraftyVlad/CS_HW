using System.Diagnostics;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Show active processes\n2. End process\n3. Start process\n4. Exit");
            Console.WriteLine("Enter option ");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    ShowProcesses();
                    break;
                case "2":
                    KillProcess();
                    break;
                case "3":
                    StartNewProcess();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    static void ShowProcesses()
    {
        Console.WriteLine("Active processes:");
        Process[] processes = Process.GetProcesses();
        foreach (Process process in processes)
        {
            Console.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}");
        }
    }

    static void KillProcess()
    {
        Console.Write("Enter process ID:");
        if (int.TryParse(Console.ReadLine(), out int processId))
        {
            try
            {
                Process process = Process.GetProcessById(processId);
                process.Kill();
                Console.WriteLine("Process ended");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Process not found");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Process already ended");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.WriteLine("Couldn't end process");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID");
        }
    }

    static void StartNewProcess()
    {
        Console.WriteLine("Enter process name (ex: notepad): ");
        string processName = Console.ReadLine()!;

        try
        {
            Process.Start(processName);
            Console.WriteLine("Process started");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

