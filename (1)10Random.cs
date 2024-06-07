class TenRandom
{
    static void Main()
    {
        int[] array = new int[10];
        Random random = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 101);
        }

        Console.WriteLine("Numbers in array:");
        foreach (int i in array)
        {
            Console.Write(i + " ");
        }

        int max = array[0];
        int min = array[0];

        foreach (int i in array)
        {
            if (i > max)
            {
                max = i;
            }
            if (i < min)
            {
                min = i;
            }
        }
        Console.WriteLine("\nMax number: " + max);
        Console.WriteLine("Min number: " + min);
    }
}
