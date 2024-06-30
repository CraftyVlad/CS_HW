public interface IProducer<out T>
{
    T Produce();
}

public interface IConsumer<in T>
{
    void Consume(T item);
}

public class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"Animal: {Name}";
    }
}

public class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override string ToString()
    {
        return $"Cat: {Name}";
    }
}

public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override string ToString()
    {
        return $"Dog: {Name}";
    }
}

public class CatProducer : IProducer<Cat>
{
    public Cat Produce()
    {
        return new Cat("Whiskers");
    }
}

public class AnimalConsumer : IConsumer<Animal>
{
    public void Consume(Animal item)
    {
        Console.WriteLine($"Consuming {item}");
    }
}

public class DogProducer : IProducer<Dog>
{
    public Dog Produce()
    {
        return new Dog("Buddy");
    }
}

public class Program
{
    public static void Main()
    {
        IProducer<Animal> animalProducer = new CatProducer();
        Animal producedAnimal = animalProducer.Produce();
        Console.WriteLine($"Produced: {producedAnimal}");

        IConsumer<Cat> catConsumer = new AnimalConsumer();
        catConsumer.Consume(new Cat("Whiskers"));

        DogProducer dogProducer = new DogProducer();
        Animal producedDog = dogProducer.Produce();
        Console.WriteLine($"Produced: {producedDog}");

        IConsumer<Dog> dogConsumer = new AnimalConsumer();
        dogConsumer.Consume(new Dog("Roofer"));
    }
}