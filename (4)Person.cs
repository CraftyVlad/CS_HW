public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Person))
        {
            return false;
        }
        Person otherPerson = (Person)obj;
        return this.Name == otherPerson.Name && this.Age == otherPerson.Age;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }
}

public class Program
{
    public static void Main()
    {
        Person person1 = new Person { Name = "John", Age = 30 };
        Person person2 = new Person { Name = "Bob", Age = 25 };
        Person person3 = new Person { Name = "Alex", Age = 30 };

        Console.WriteLine("Person 1: " + person1);
        Console.WriteLine("Person 2: " + person2);
        Console.WriteLine("Person 3: " + person3);

        Console.WriteLine("Equality between Person 1 and Person 2: " + person1.Equals(person2));
        Console.WriteLine("Equality between Person 1 and Person 3: " + person1.Equals(person3));

        Console.WriteLine("Hash code of Person 1: " + person1.GetHashCode());
        Console.WriteLine("Hash code of Person 2: " + person2.GetHashCode());
        Console.WriteLine("Hash code of Person 3: " + person3.GetHashCode());
    }
}