class Program
{
    public static async Task<int> CalculateSumAsync(int[] array)
    {
        return await Task.Run(() => array.Sum());
    }

    public static async Task RunSumCalculationsAsync()
    {
        int[] array1 = Enumerable.Range(1, 1000).ToArray();
        int[] array2 = Enumerable.Range(1, 2000).ToArray();
        int[] array3 = Enumerable.Range(1, 3000).ToArray();

        Task<int> sum1 = CalculateSumAsync(array1);
        Task<int> sum2 = CalculateSumAsync(array2);
        Task<int> sum3 = CalculateSumAsync(array3);

        try
        {
            Task<int[]> allTasks = Task.WhenAll(sum1, sum2, sum3);
            int[] results = await allTasks;

            Console.WriteLine($"Sum of array 1: {results[0]}, array 2: {results[1]}, array 3: {results[2]}");

            Task<int> firstCompletedTask = await Task.WhenAny(sum1, sum2, sum3);
            Console.WriteLine($"First completed task: {firstCompletedTask.Result}");
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task Main()
    {
        await RunSumCalculationsAsync();
    }
}