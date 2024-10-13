//class Program
//{
//    public static async Task<int> CalculateFactorialAsync(int number)
//    {
//        if (number < 0)
//        {
//            throw new ArgumentException("Number cant be negative.");
//        }

//        return await Task.Run(() => CalculateFactorial(number));
//    }

//    private static int CalculateFactorial(int number)
//    {
//        if (number == 0 || number == 1)
//            return 1;

//        int result = 1;
//        for (int i = 2; i <= number; i++)
//        {
//            result *= i;
//        }
//        return result;
//    }

//    public static async Task RunCalculationsAsync()
//    {
//        try
//        {
//            int[] numbers = { 5, 10, 15 };
//            Task<int>[] tasks = new Task<int>[numbers.Length];

//            for (int i = 0; i < numbers.Length; i++)
//            {
//                tasks[i] = CalculateFactorialAsync(numbers[i]);
//            }

//            int[] results = await Task.WhenAll(tasks);
//            for (int i = 0; i < results.Length; i++)
//            {
//                Console.WriteLine($"{numbers[i]}! = {results[i]}");
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error: {ex.Message}");
//        }
//    }

//    static async Task Main()
//    {
//        await RunCalculationsAsync();
//    }
//}
