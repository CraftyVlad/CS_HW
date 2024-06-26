record Person(string Name, int Age);

class Program
{
    static void Main()
    {
        var person = new Person("John", 20);
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        var updatedPerson = person with { Age = 21 };
        Console.WriteLine($"Updated age: {updatedPerson.Age}");
    }
}