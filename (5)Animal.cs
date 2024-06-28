class Animal
{
    public string Name { get; set; }
    public Animal(string name)
    {
        Name = name;
    }
}

class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }
}

class Program
{
    delegate Animal AnimalDelegate(Animal animal);
    delegate Dog DogDelegate(Dog dog);

    static Animal ReturnAnimal(Animal animal)
    {
        Console.WriteLine($"Animal name: {animal.Name}");
        return animal;
    }

    static Dog ReturnDog(Dog dog)
    {
        Console.WriteLine($"Dog name: {dog.Name}");
        return dog;
    }

    static void Main()
    {
        Animal animal = new Animal("Animal");
        Dog dog = new Dog("Dog");

        AnimalDelegate animalDelegate = ReturnAnimal;
        DogDelegate dogDelegate = ReturnDog;

        animalDelegate(animal);
        dogDelegate(dog);
    }
}