class NumberSum
{
    static int SumArray(int[] arr)
    {
        int Add(int a, int b)
        {
            return a + b;
        }

        int result = 0;

        foreach (int i in arr)
        {
            result = Add(result, i);
        }

        return result;
    }
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Console.WriteLine(SumArray(arr));
    }
}