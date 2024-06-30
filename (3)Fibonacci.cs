public class FibonacciSequence
{
    private readonly int? _maxCount;

    public FibonacciSequence(int? maxCount = null)
    {
        _maxCount = maxCount;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return Generate().GetEnumerator();
    }

    private IEnumerable<int> Generate()
    {
        int a = 0;
        int b = 1;
        int count = 0;

        while (!_maxCount.HasValue || count < _maxCount.Value)
        {
            yield return a;
            int temp = a;
            a = b;
            b = temp + b;
            count++;
        }
    }

    
}

public class Program
{
    public static void Main()
    {
        FibonacciSequence fibSeq = new FibonacciSequence(20);

        foreach (int number in fibSeq)
        {
            Console.WriteLine(number);
        }
    }
}