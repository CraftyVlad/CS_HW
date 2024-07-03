class Program
{
    static int SumOfDigits(int num)
    {
        return num.ToString().Sum(digit => digit - '0');
    }

    static int[] SortBySumOfDigitsAscending(int[] array)
    {
        return array.OrderBy(SumOfDigits).ToArray();
    }

    static int[] SortBySumOfDigitsDescending(int[] array)
    {
        return array.OrderByDescending(SumOfDigits).ToArray();
    }

    static void Main()
    {
        int[] array = { 121, 75, 81 };

        int[] sortedArrayAscending = SortBySumOfDigitsAscending(array);
        int[] sortedArrayDescending = SortBySumOfDigitsDescending(array);

        Console.WriteLine(string.Join(", ", sortedArrayAscending));
        Console.WriteLine(string.Join(", ", sortedArrayDescending));
    }
}