public static class Cortege
{
    public static void PrintInfo(this (string name, int age, string location) person)
    {
        Console.WriteLine($"Name: {person.name}, Age: {person.age}, Location: {person.location}");
    }
}

class Program
{
    static void Main()
    {
        var person = ("John", 20, "Washington DC");
        person.PrintInfo();
    }
}