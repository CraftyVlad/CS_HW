class BaseEntity<T>
{
    public T Id { get; set; }
}

class Person<T> : BaseEntity<T>
{
    public string Name { get; set; }
}

class Employee<T> : Person<T>
{
    public string Position { get; set; }
}

class Program
{
    static void Main()
    {
        Employee<int> employee1 = new Employee<int>
        {
            Id = 1,
            Name = "John Doe",
            Position = "Cashier"
        };

        Employee<string> employee2 = new Employee<string>
        {
            Id = "two",
            Name = "Alex Doe",
            Position = "Cashier"
        };

        Console.WriteLine($"Employee 1: Id = {employee1.Id}, Name = {employee1.Name}, Position = {employee1.Position}.");
        Console.WriteLine($"Employee 2: Id = {employee2.Id}, Name = {employee2.Name}, Position = {employee2.Position}.");
    }
}