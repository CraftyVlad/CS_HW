using System.Diagnostics;

class Program
{
    static Stopwatch sw = new Stopwatch();
    static void Main()
    {
        Console.WriteLine("Game starting. Press ENTER when you see the signal");

        Thread signalThread = new Thread(GenerateSignal);
        signalThread.Start();

        Console.ReadLine();
        if (sw.IsRunning)
        {
            sw.Stop();
            Console.WriteLine($"Your reaction time: {sw.ElapsedMilliseconds} ms");
        }
        else
        {
            Console.WriteLine("You pressed to early!");
        }

    }

    static void GenerateSignal()
    {
        Thread.Sleep(new Random().Next(1000, 5000));

        Console.WriteLine("Signal!");

        sw.Start();
    }
}