class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Enter dictionary name: ");
        string dictName = Console.ReadLine()!;

        Console.Write("Enter dictionary type (e.g., English-Ukrainian or Ukrainian-English): ");
        string dictType = Console.ReadLine()!;

        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        while (true)
        {
            Console.WriteLine("\nMenu: \n1. Add word and its translations\n2. Replace word or translation\n3. Delete word or translation\n4. Search for word translation\n5. Export dictionary to file\n6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine()!;

            if (choice == "1")
            {
                Console.Write("Enter word: ");
                string word = Console.ReadLine()!;

                Console.Write("Enter translations (comma-separated): ");
                string[] translations = Console.ReadLine()!.Split(',');

                if (dictionary.ContainsKey(word))
                {
                    dictionary[word].AddRange(translations);
                }
                else
                {
                    dictionary[word] = new List<string>(translations);
                }

                Console.WriteLine($"Word '{word}' with translations {string.Join(", ", translations)} added to the dictionary.");
            }
            else if (choice == "2")
            {
                Console.Write("Enter word to replace: ");
                string word = Console.ReadLine()!;

                if (dictionary.ContainsKey(word))
                {
                    Console.Write("Enter new word (or press Enter to leave unchanged): ");
                    string newWord = Console.ReadLine()!;

                    Console.Write("Enter new translations (or press Enter to leave unchanged): ");
                    string[] newTranslations = Console.ReadLine()!.Split(new[] { ',' });

                    if (!string.IsNullOrEmpty(newWord))
                    {
                        dictionary[newWord] = dictionary[word];
                        dictionary.Remove(word);
                        word = newWord;
                    }

                    if (newTranslations.Length > 0)
                    {
                        dictionary[word] = new List<string>(newTranslations);
                    }

                    Console.WriteLine($"Word '{word}' replaced.");
                }
                else
                {
                    Console.WriteLine($"Word '{word}' not found in the dictionary.");
                }
            }
            else if (choice == "3")
            {
                Console.Write("Enter word to delete: ");
                string word = Console.ReadLine()!;

                if (dictionary.ContainsKey(word))
                {
                    dictionary.Remove(word);
                    Console.WriteLine($"Word '{word}' and all its translations deleted.");
                }
                else
                {
                    Console.WriteLine($"Word '{word}' not found in the dictionary.");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Enter word to search for translation: ");
                string word = Console.ReadLine()!;

                if (dictionary.ContainsKey(word))
                {
                    Console.WriteLine($"Translations for '{word}': {string.Join(", ", dictionary[word])}");
                }
                else
                {
                    Console.WriteLine($"Word '{word}' not found in the dictionary.");
                }
            }
            else if (choice == "5")
            {
                Console.Write("Enter file path (Example: '../../../'): ");
                string filePath = Console.ReadLine()!;
                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine()!;
                string newFile = filePath + fileName + ".txt";

                using (StreamWriter writer = new StreamWriter(newFile))
                {
                    writer.WriteLine($"Dictionary name: {dictName}\nDictionary type: {dictType}\n\nTranslations:");
                    foreach (var entry in dictionary)
                    {
                        writer.WriteLine($"{entry.Key} : {string.Join(",", entry.Value)}");
                    }
                }
                Console.WriteLine($"Dictionary exported to file '{fileName + ".txt"}'.");
            }
            else if (choice == "6")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        Console.WriteLine("Program finished.");
    }
}
