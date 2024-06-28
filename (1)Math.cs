delegate int MathOperation(int a, int b);

class Program
{
    static int Add(int a, int b)
    {
        return a + b;
    }

    static int Subtract(int a, int b)
    {
        return a - b;
    }

    static int Multiply(int a, int b)
    {
        return a * b;
    }

    static int Divide(int a, int b)
    {
        if (b != 0)
        {
            return a / b;
        }
        else
        {
            throw new DivideByZeroException("Divided by zero!");
        }
    }

    static void Main()
    {
        MathOperation add = Add;
        MathOperation subtract = Subtract;
        MathOperation multiply = Multiply;
        MathOperation divide = Divide;

        int num1 = 5;
        int num2 = 2;

        Console.WriteLine($"Addition: {Add(num1, num2)}");
        Console.WriteLine($"Subtraction: {Subtract(num1, num2)}");
        Console.WriteLine($"Multiplication: {Multiply(num1, num2)}");
        Console.WriteLine($"Division: {Divide(num1, num2)}");
    }
}