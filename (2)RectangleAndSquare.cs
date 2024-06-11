struct Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }

    // Constructor
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public double GetSquareArea(double sideLength)
    {
        return sideLength * sideLength;
    }

    public double GetPerimeter()
    {
        return 2 * (Width + Height);
    }

    public static Rectangle CombineAreas(Rectangle rect1, Rectangle rect2)
    {
        double combinedArea = rect1.GetArea() + rect2.GetArea();
        double side1 = rect1.Width + rect2.Width;
        double side2 = rect1.Height + rect2.Height;
        return new Rectangle(side1, side2);
    }
}

class Program
{
    static void Main()
    {
        Rectangle rect1 = new Rectangle(4, 5);
        Rectangle rect2 = new Rectangle(3, 6);

        Console.WriteLine("Rectangle 1:");
        Console.WriteLine($"Width: {rect1.Width}, Height: {rect1.Height}");
        Console.WriteLine($"Area: {rect1.GetArea()}");
        Console.WriteLine($"Perimeter: {rect1.GetPerimeter()}");

        Console.WriteLine("\nRectangle 2:");
        Console.WriteLine($"Width: {rect2.Width}, Height: {rect2.Height}");
        Console.WriteLine($"Area: {rect2.GetArea()}");
        Console.WriteLine($"Perimeter: {rect2.GetPerimeter()}");

        Rectangle combinedRect = Rectangle.CombineAreas(rect1, rect2);
        Console.WriteLine("\nCombined Rectangle:");
        Console.WriteLine($"Width: {combinedRect.Width}, Height: {combinedRect.Height}");
        Console.WriteLine($"Area: {combinedRect.GetArea()}");
        Console.WriteLine($"Perimeter: {combinedRect.GetPerimeter()}");

        double sideLength = 4;
        Console.WriteLine($"\nArea of square with side length of {sideLength}: {rect1.GetSquareArea(sideLength)}");
    }
}