public class EventProcessor<T>
{
    public delegate void ProcessorHandler(T item);
    public event ProcessorHandler? ProcessorEvent;

    private void DataProcessed(T message)
    {
        ProcessorEvent?.Invoke(message);
    }

    public void ProcessData(T item, Func<T, T> func)
    {
        T result = func(item);
        this.DataProcessed(result);
    }
}

class Program
{
    static void Main()
    {
        EventProcessor<string> eventProcessor = new EventProcessor<string>();
        eventProcessor.ProcessorEvent += (str) => Console.WriteLine(str);
        eventProcessor.ProcessData("Hello", x => x + x + x);
    }
}