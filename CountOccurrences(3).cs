class CountOccurrences
{
    static void Main()
    {
        int[] array = new int[20];
        Random random = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 11);
        }

        int numberToFind = 5;
        int count = CountOccurrences(array, numberToFind);
        Console.WriteLine("Numbers in array: " + string.Join(", ", array));

        static int CountOccurrences(int[] array, int number)
        {
            int count = 0;

            foreach (int i in array)
            {
                if (i == number)
                {
                    count++;
                }
            }
            return count;
        }
        Console.WriteLine($"The number of occurrences of the number {numberToFind} in the array is: {count}");
    }
}