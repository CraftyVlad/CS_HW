using System.Diagnostics;

class Program
{
    static async Task Main()
    {
        Random rnd = new Random();
        Stopwatch sw = new Stopwatch();

        Console.WriteLine("Press ENTER when you see the signal");
        await Task.Delay(rnd.Next(1000, 5000));

        Console.WriteLine("SIGNAL!!");

        sw.Start();
        await Task.Run(() => Console.ReadKey());
        sw.Stop();

        Console.WriteLine($"Reaction time: {sw.ElapsedMilliseconds} ms");
    }
}