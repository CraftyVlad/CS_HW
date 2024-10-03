using System.Reflection;
using System.Runtime.Loader;

class Program
{
    static void Main()
    {
        string assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "CS_HW.dll");
        
        var context = new AssemblyLoadContext("MathLibraryContext", isCollectible: true);

        Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);

        Type calculatorType = assembly.GetType("Calculator")!;
        MethodInfo multiplyMethod = calculatorType.GetMethod("Multiply")!;

        object calculatorInstance = Activator.CreateInstance(calculatorType)!;
        int result = (int)multiplyMethod.Invoke(calculatorInstance, new object[] { 5, 5 })!;

        Console.WriteLine($"{result}");

        context.Unload();
        
    }
}