class Contact
{
    public string Name { get; set; }
    public string Number { get; set; }

    public Contact(string name, string number)
    {
        Name = name;
        Number = number;
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, string> contacts = new Dictionary<string, string>
        {
            { "John", "(97) 123-4567" },
            { "Bob", "(97) 765-4321" }
        };

        Console.WriteLine($"Amount of contacts: {contacts.Count}");

        if (contacts.ContainsKey("John"))
        {
            Console.WriteLine($"Contact John: {contacts["John"]}");
        }
        else
        {
            Console.WriteLine($"Contact John not found.");
        }

        contacts["Alice"] = "(96) 203-2041";
        Console.WriteLine($"New contact Alice: {contacts["Alice"]}");

        if (contacts.ContainsKey("Bob"))
        {
            contacts.Remove("Bob");
            Console.WriteLine("Contact Bob has been deleted.");
        }
        else
        {
            Console.WriteLine("Contact Bob not found.");
        }

        Console.WriteLine("\nNew contact list:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Key}: {contact.Value}");
        }
    }
}