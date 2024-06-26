record Rectangle(double Length, double Width)
{
    public double CalculateArea()
    {
        return Length * Width;
    }
}

class Program
{
    static void Main()
    {
        var rectangle = new Rectangle(10, 5);
        double area = rectangle.CalculateArea();
        Console.WriteLine(area);
    }
}