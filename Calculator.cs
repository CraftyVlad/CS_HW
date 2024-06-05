class Calculator
{
    static void Main()
    {
        double num1, num2, result;
        char symbol;

        Console.Write("Enter the first number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the symbol (+, -, *, /): ");
        symbol = Convert.ToChar(Console.ReadLine()!);

        switch (symbol)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                result = num1 / num2;
                break;
            default:
                Console.Write("Invalid operation");
                return;
        }

        Console.Write("Result: " + result);
    }
}
