namespace MathLibrary
{
    public static class MathOperations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Add(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
        public static int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cant be divided by 0.");
            }
            return a / b;
        }
    }
}
