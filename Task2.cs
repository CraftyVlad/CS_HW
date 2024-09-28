using System.Reflection;

class Program
{
    static void Main()
    {
        Assembly assembly = Assembly.LoadFrom("CS_HW.dll");

        Type mathType = assembly.GetType("MathOperations");
        if (mathType == null)
        {
            Console.WriteLine("Class not found");
            return;
        }

        object mathInstance = Activator.CreateInstance(mathType);

        Console.WriteLine("Choose method:\n1. Add\n2. Subtract");
        string choice = Console.ReadLine();

        MethodInfo method = null;

        switch (choice)
        {
            case "1":
                method = mathType.GetMethod("Add");
                break;
            case "2":
                method = mathType.GetMethod("Subtract");
                break;
            default:
                Console.WriteLine("Invalid choice");
                return;
        }

        object? result = method.Invoke(mathInstance, new object[] { 5, 3 });
        Console.WriteLine($"Result: {result}");
    }
}