using System.Reflection;

public class ClassOne
{
    public void Method1()
    {
        Console.WriteLine("Method1");
    }

    public void Method2(int a, string b)
    {
        Console.WriteLine("Method2");
    }

    public void Method3(double x)
    {
        Console.WriteLine("Method3");
    }
}

class Program
{
    static void Main()
    {
        Type type = typeof(ClassOne);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        foreach (var method in methods)
        {
            ParameterInfo[] parameters = method.GetParameters();
            Console.WriteLine($"Method name: {method.Name}, amount of parameters: {parameters.Length}");

            foreach (var param in parameters)
            {
                Console.WriteLine($"    Param name: {param.Name}, type: {param.ParameterType}");
            }
        }

        var sortedMethods = methods.OrderBy(m => m.GetParameters().Length).ToList();

        Console.WriteLine("\nMethods sorted by amount of parameters:");
        foreach (var method in sortedMethods)
        {
            Console.WriteLine($"    Name: {method.Name}, Amount of parameters: {method.GetParameters().Length}");
        }
    }
}