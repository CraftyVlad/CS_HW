using System.Reflection;

class ClassOne
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ClassOne(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class ClassTwo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }

    public ClassTwo(int id, string name, int value)
    {
        Id = id;
        Name = name;
        Value = value;
    }
}

class Task1
{
    static void Main()
    {
        Console.WriteLine("Enter class name:");
        string className = Console.ReadLine();

        Type type = Type.GetType(className);

        if (type == null)
        {
            Console.WriteLine("Class not found");
            return;
        }

        Console.WriteLine("\nConstructors:");
        ConstructorInfo[] constructors = type.GetConstructors();
        foreach (ConstructorInfo constructor in constructors)
        {
            Console.WriteLine(constructor.ToString());
        }

        Console.WriteLine("\nMethods:");
        MethodInfo[] methods = type.GetMethods();
        foreach (MethodInfo method in methods)
        {
            ParameterInfo[] parameters = method.GetParameters();
            foreach (ParameterInfo param in parameters)
            {
                Console.WriteLine($"Name: {method.Name}, Returns: {method.ReturnType}, Parameter name: {param.Name}, Type: {param.ParameterType}");

            }
        }

        Console.WriteLine("\nFields:");
        FieldInfo[] fields = type.GetFields();
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine($"Name: {field.Name}, Type: {field.FieldType}");
        }

        Console.WriteLine("\nProperties:");
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"Name: {property.Name}, Type: {property.PropertyType}");
        }
    }
}