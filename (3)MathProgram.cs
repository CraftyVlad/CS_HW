using MathLibrary;

namespace MathConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Addition of 2 numbers: " + MathOperations.Add(3, 5));
            Console.WriteLine("Addition of more than 2 numbers: " + MathOperations.Add(1, 2, 3, 4, 5));
            Console.WriteLine("Subtraction of 2 numbers: " + MathOperations.Subtract(10, 4));
            Console.WriteLine("Multiplication of 2 numbers: " + MathOperations.Multiply(6, 7));
            Console.WriteLine("Division of 2 numbers: " + MathOperations.Divide(20, 4));

            try
            {
                Console.WriteLine("Divided by 0: " + MathOperations.Divide(10, 0));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
